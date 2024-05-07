// Stoasy (Synchronous to asynchronous)
// Copyright (c) 2020, Siemens AG
//
// Author: Roland Eckl, DI ST PI AP
//

importScripts('../libs/swac-boot.min.js');
importScripts('./alpha.js');
importScripts('./gamma.js');
importScripts('./delta.js');
importScripts('./epsilon.js');
importScripts('./proxy.js');
importScripts('./zeta.js');

let context = {};

async function evalInContext(id, code) {
    // Each context has its own HmiRuntime object.
    let HMIRuntime = createProxy(id, null, ['UI','Language','Tags','Math','Resources'], ['Trace','GetDetailedErrorDescription','Tags'], [], { LocalTrace: function(a) { console.log('Worker-Trace: ' + a); }});
    let Screen = createProxy(id, id, [
        'ScreenNumber', 'ScreenMaster', 'CurrentStyle', 'EnableExplicitUnlock', 'Authorization', 'Operability', 'RequireExplicitUnlock', 'OffsetLeft', 'OffsetTop', 'Enabled', 'Width', 'Height',
        'BackFillPattern', 'BackColor', 'AlternateBackColor', 'BackGraphic', 'HorizontalAlignment', 'VerticalAlignment', 'BackgroundFillMode', 'BackGraphicStretchMode', 'Name',
        'DisplayName', 'Layers', 'Parent', 'CurrentWindow', 'ParentScreen', 'Items', 'DataSet'
    ], ['Items','DataSet','Windows','FindItem','Layers'], [], { LocalTrace: function(a) { console.log('Worker-Trace: ' + a); }});

    // Alias
    let UI = HMIRuntime.UI;
    let Resources = HMIRuntime.Resources;
    let Tags = await HMIRuntime.Tags;
    Tags.Enums = {
        hmiWriteType: { hmiWriteNoWait:0, hmiWriteWait:1 },
        hmiReadType: { hmiReadCache:0, hmiReadDirect:1 }
    };

    // without await the object is ambivalent. To add something the object has to be awaited and aftwerwards marked as ambivalent again.
    Tags = createAmbivalent(id, 'Tags', Tags);
    eval(code);
    // Adding β to the context here would be too late, because all local definitions not explicitly added to the context via this.<whatever> = ... would be lost with eval ending (local stuff got lost with eval's scope)
}

// Worker's interface
let inf = (function () {
    let methods = {
        register: async function (id, code) {
            await initialization; // if still pending, wait.
            try {
                methods.dispose(id) // clean up if context was already set.
                context[id] = {}; // new context for given ID
                await evalInContext.call(context[id], id, code);
                return true;
            } catch(ex) {};
            methods.dispose(id); // clean up (again) if something failed.
            return false;
        },
        dispose: function(id) {
            try {
                if(!context[id])
                    return false;
                delete context[id].β; // removing that function should remove also its scope holding objects not explicitly set on the context
                delete context[id];   // deleting (not null-ing) so the key is also gone.
            } catch(ex) {};
        },
        list: function() {
            return Object.keys(context);
        },
        invoke: async function(id, method, ...args) {
            try {
                let realArgs = [];
                if(args && args.length > 0){
                for(let i = 0; i < args.length; i++){
                        let prev = args[i];
                        if(typeof prev == 'object'){
                            if(prev.t && prev.t == 'plain'){
                                realArgs.push(prev.v);
                            } else if (prev.t && prev.t == 'remote') {
                                realArgs.push(createProxy(id, prev.path, prev.properties, prev.functions, prev.async));
                            } else {
                                realArgs.push(prev); // fallback, usually all arguments should be boxed as plain or remote
                            }
                        } else {
                            realArgs.push(prev); // fallback, usually all arguments should be boxed as plain or remote
                        }
                    }
                }
                let res = await α(context[id].β.call(context[id], method, realArgs)); // β's scope has still access to the scope of eval when registering the code.
                res = boxResult(res);
                return res;
            } catch(ex) {};
        }
    };
    return methods;
}());

let somResolver = null;

// the following promise will be pending until boot phase successfully passed and we got all necessary services.
// (Otherwise beginExpose might trigger actions on container-side and scripts get registered before the service is availble... defining alias depending on somResolver fails then.)
const initialization = new Promise((resolve) => {
    let r = (async () => {
        SWACBoot.start(async function (got) {
            let hub = new got.SWAC.Hub(inf);
            await hub.beginExpose();
            somResolver = await hub.services.beginGet('somResolver');
            resolve(); // finally: resolve and let incoming calls at the interface proceed.
        });
    })();
});
