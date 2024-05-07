// Stoasy (Synchronous to asynchronous)
// Copyright (c) 2020, Siemens AG
//
// Author: Roland Eckl, DI ST PI AP
//

let proxyObject = function(c, p, r, f, af, l, a, tn, isinstance) {
    const intern = tn ? getproto(tn, true) : (a ? function(...args){ return createInvoke(c, p, false /* ambi expected to have no async signature */, ...args); } : {} );
    intern.context = c;
    intern.path = p;
    intern.remote = r || [];
    intern.fun = f || [];
    intern.afun = af || [];
    intern.local = l || {};
    if(!isinstance) {
        intern.proto = tn;
    }
    return intern;
};

let isProxy = Symbol("path");
let isProto = Symbol("proto");

let proxyHandler = {
    get: function (oTarget, sKey) {
        // Assumption: Remoted objects never have properties called constructor or then.
        if(sKey === 'constructor' || sKey === 'then')
            return;

        if(sKey == isProxy)
            return {proxy: true, path: oTarget.path};

        if(oTarget.proto && sKey == isProto)
            return getproto(oTarget.proto, false);

        if(oTarget.local[sKey] !== undefined)
            return oTarget.local[sKey];

        if(oTarget.remote.includes(sKey)){
            let v = peek(oTarget.context, oTarget.path ? oTarget.path + '.' + sKey : sKey, /** ambivalent? **/ oTarget.fun.includes(sKey));
            return v;
        }
        if(oTarget.fun.includes(sKey)){
            return function(...args){
                return createInvoke(oTarget.context, oTarget.path ? oTarget.path + '.' + sKey : sKey, false, ...args);
            }
        }
        if(oTarget.afun.includes(sKey)){
            return function(...args){
                return createInvoke(oTarget.context, oTarget.path ? oTarget.path + '.' + sKey : sKey, true, ...args);
            }
        }
        if(!isNaN(parseInt(sKey))){
            let v = peekIndex(oTarget.context, oTarget.path ? oTarget.path + '.' + sKey : sKey, /** ambivalent? **/ oTarget.fun.includes(sKey));
            return v;
        }
        return undefined;
    },
    set: async function (oTarget, sKey, vValue) {
        if (oTarget.remote.includes(sKey)) {
            try {
                let val = JSON.parse(JSON.stringify(vValue));
                return await poke(oTarget.context, oTarget.path ? oTarget.path + '.' + sKey : sKey, val);
            } catch(ex) { }
        }

        // Value could not be serialized, set it locally.
        delete oTarget.remote[sKey];
        delete oTarget.fun[sKey];
        oTarget.local[sKey] = vValue;

        return true;
    },
    has: function (oTarget, sKey) {
        return (oTarget.local[sKey] !== undefined) || oTarget.remote.includes(sKey) || oTarget.fun.includes(sKey) || oTarget.afun.includes(sKey);
    },
    ownKeys: function (oTarget) {
        return getUniqueArray(oTarget.local, oTarget.remote, oTarget.fun, oTarget.afun);
    },
    enumerate: function (oTarget) {
        return getUniqueArray(oTarget.local, oTarget.remote, oTarget.fun, oTarget.afun);
    },
    getOwnPropertyDescriptor: function (oTarget, sKey) {
        let keys = getUniqueArray(oTarget.local, oTarget.remote, oTarget.fun, oTarget.afun);
        if(keys.includes(sKey)) {
            return {
                enumerable: true,
                configurable: true
            };
        }
        return undefined;
    }
};

function getUniqueArray(local, remote, fun, afun){
    const array = Object.keys(local || {}).concat(remote || []).concat(fun || []).concat(afun || []);
    return [...new Set(array)];
}

function createProxy(c, p, r, f, af, l, amb, tn, isinstance ){
    return new Proxy(proxyObject(c, p, r, f, af, l, amb, tn, isinstance), proxyHandler);
}

function peek (context, path, amb = false) {
    let promise = new γ(async function(resolve, reject) {
        try{
            let remote = await somResolver.resolve(context, path);
            // Plain value?
            if(remote.t !== 'remote'){
                resolve(remote.v);
                return;
            }
            // Otherwise create next proxy
            var proxy = createProxy(context, remote.path ? remote.path : path, remote.properties, remote.functions, remote.async, undefined, remote.ambivalent, remote.proto, remote.instance);
            resolve(proxy);
        }
        catch(ex) {
            reject();
        }
    });

    if(amb){
        return createAmbivalent(context, path, promise);
    }
    return promise;
}

function peekIndex (context, path, amb = false) {
    let promise = new γ(async function(resolve, reject) {
        try{
            let remote = await somResolver.resolve(context, path, true);
            // Plain value?
            if(remote.t !== 'remote'){
                resolve(remote.v);
                return;
            }
            // Otherwise create next proxy
            var proxy = createProxy(context, remote.path ? remote.path : path, remote.properties, remote.functions, remote.async, undefined, remote.ambivalent, remote.proto, remote.instance);
            resolve(proxy);
        }
        catch(ex) {
            reject();
        }
    });

    if(amb){
        return createAmbivalent(context, path, promise);
    }
    return promise;
}

async function poke(context, path, value){
    return await somResolver.trySet(context, path, value);
}

const pmapping = {};

// creates a new prototype for an ambivalent function
function getproto(name, instantiate = false) {
    if(!pmapping[name]){
        let proto = function() { /* empty */ }
        if(!name){
            return instantiate ? new proto() : proto;
        }
        pmapping[name] = proto;
    }
    return instantiate ? new pmapping[name]() : pmapping[name];
 }

function createAmbivalent(context, path, thing){
    const ambivalent = function(...args){
            let p = new Promise((resolve) => {
                let r = createInvoke(context, path, false /* ambi expected to have no async signature */, ...args);
                r.then(function (val) {
                    resolve(val);
                });
            });
            return p;
        };

    ambivalent.then = function(resolve){
        // if used like an object, chain the promise we'd have returned a non-ambivalent object.
        resolve(thing);
    }
    return ambivalent;
}

function boxResult(result) {
    const check = result ? result[isProxy] : result;
    if(check && check.proxy){
        return {t: 'remote', path: check.path };
    } else {
        // TODO: Add hints for Big and DateTime and turn into tuple?
        return {t: 'plain', v: result};
    }
}

async function createInvoke(context, path, immediately, ...args){
    // repackage remotables if needed.
    if(Array.isArray(args)){
        for(let i = 0; i < args.length; i++){
            args[i] = boxResult(args[i]);
        }
    }

    if(immediately){
        let p = new Promise((resolve, reject) => {
            let r = somResolver.invoke(context, path, ...args);
            if(r){
                r.then(function (val) {
                    let res = processReturnValue(context, path, val)
                    resolve(res);
                }, function(reason) {
                    reject(reason);
                });
            }
            else {
                return r;
            }
        });
        return p;
    }
    const res = await somResolver.invoke(context, path, ...args);
    return processReturnValue(context, path, res);
}

function processReturnValue(context, path, res){
    if(res){
        if(Array.isArray(res)){
            // Look through all entries, might be a collection containing remotables. (TODO: Consider having a specific type next to plain and remote which says "contains remotes")
            const result = [];
            for(let i = 0; i < res.length; i++){
                const entry = res[i];
                if(entry.t !== 'remote'){
                    result.push(entry.v);
                } else {
                    const proxy = createProxy(context, entry.path ? entry.path : path, entry.properties, entry.functions, entry.async, undefined, entry.ambivalent, entry.proto, entry.instance);
                    if(entry.ambivalent){
                        result.push(createAmbivalent(context, entry.path, proxy));
                    } else {
                        result.push(proxy);
                    }
                }
            }
            return result;
        }
        else if(res.t === 'exception'){
            throw res.v ? res.v : 'Unknown exception';
        }
        else if(res.t !== 'remote') {
            return res.v;
        }
        else {
            // Otherwise create next proxy
            const proxy = createProxy(context, res.path ? res.path : path, res.properties, res.functions, res.async, undefined, res.ambivalent, res.proto, res.instance);
            if(res.ambivalent){
                return createAmbivalent(context, res.path, proxy);
            }
            return proxy;
        }
    }
    return res; // undefined
}
