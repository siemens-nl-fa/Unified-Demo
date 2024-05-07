// Stoasy (Synchronous to asynchronous)
// Copyright (c) 2020, Siemens AG
//
// Author: Roland Eckl, DI TI SYA
//
// Checks wether the boxed value is our special promise γ and awaits only that one.
//

async function α(f, any = false) {
    return f && f.constructor && (f.constructor.name === 'γ' || ( any && f.constructor.name === 'Promise')) ? await f : f;
};