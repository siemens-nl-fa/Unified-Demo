// Stoasy (Synchronous to asynchronous)
// Copyright (c) 2020, Siemens AG
//
// Author: Roland Eckl, DI TI SYA
//
// Special promise derived from browser's native promise. Allows to differentiate between regular promises and all async code Stoasy introduced.
//

function γ(executor) {
    var p = new Promise(function (resolve, reject) {
        // before
        return executor(resolve, reject);
    });
    // after
    p.__proto__ = γ.prototype;
    return p;
}

γ.__proto__ = Promise;
γ.prototype.__proto__ = Promise.prototype;
γ.prototype.then = function then(onFulfilled, onRejected) {
    // before
    var returnValue = Promise.prototype.then.call(this, onFulfilled, onRejected);
    // after
    return returnValue;
}

/* equivalent in ES6 style

class γ extends Promise {
    constructor(executor) {
        super((resolve, reject) => {
            // before
            return executor(resolve, reject);
        });
        // after
    }

    then(onFulfilled, onRejected) {
        // before
        const returnValue = super.then(onFulfilled, onRejected);
        // after
        return returnValue;
    }
}
*/