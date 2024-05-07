// Stoasy (Synchronous to asynchronous)
// Copyright (c) 2020, Siemens AG
//
// Author: Roland Eckl, DI TI SYA
//
// Updates (e.g. i++) need special handling.
//

async function δ(member, identifier, operator, prefix) {
    let value = await α(member[identifier], true);
    let nvalue = value + (operator == '++' ? 1 : -1);
    await α(member[identifier] = nvalue);
    return prefix ? nvalue : value;
}


async function δreduce(arr, callbackFn, initialValue) {
    return arr.reduce(async (accumulator, currentValue, currentIndex, array) => {
	    const memo = await accumulator;
	    return await callbackFn(memo, currentValue, currentIndex, array);
    }, initialValue);
}

async function δreduceRight(arr, callbackFn, initialValue) {
    return arr.reduceRight(async (accumulator, currentValue, currentIndex, array) => {
	    const memo = await accumulator;
	    return await callbackFn(memo, currentValue, currentIndex, array);
    }, initialValue);
}

async function δmap(arr, callbackFn) {
    const mappedResults = [];
    for (const [index, element] of arr.entries()) {
      const mappedResult = await callbackFn(element, index, arr);
      mappedResults.push(mappedResult);
    }

    return mappedResults;
}

async function δflatMap(arr, callbackFn) {
    const results = await δmap(arr, callbackFn);
    // reduce + concat is faster than flat
    return results.reduce( (accumulator, currentValue) => {
            return (Array.isArray(currentValue) ? accumulator.concat(...currentValue) : accumulator.concat(currentValue));
        },
        []
    );
}

async function δforEach(arr, callbackFn) {
    // you can't use await within a forEach()
    for (const [index, element] of arr.entries()) {
        await callbackFn(element, index, arr);
    }
}

async function δfilter(arr, callbackFn) {
    const filteredResults = [];
    for (const [index, element] of arr.entries()) {
        if (await callbackFn(element, index, arr)) {
            filteredResults.push(element);
        }
    }

    return filteredResults;
}

async function δfind(arr, callbackFn) {
    for (const [index, element] of arr.entries()) {
        if (await callbackFn(element, index, arr)) {
            return element;
        }
    }

    return undefined;
}

async function δfindIndex(arr, callbackFn) {
    for (const [index, element] of arr.entries()) {
        if (await callbackFn(element, index, arr)) {
            return index;
        }
    }

    return -1;
}

async function δsome(arr, predicate) {
    for (let e of arr) {
        if (await predicate(e)) {
            return true;
        }
    }
    return false;
}

async function δevery(arr, predicate) {
    for (let e of arr) {
      if (!await predicate(e)) {
        return false;
      }
    }
    return true;
}






