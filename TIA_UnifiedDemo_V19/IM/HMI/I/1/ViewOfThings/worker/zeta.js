// Stoasy (Synchronous to asynchronous)
// Copyright (c) 2020, Siemens AG
//
// Author: Roland Eckl, DI ST PI AP
//
// Checks wether a is an instance of b. In case of remoteable objects, it will check for the original prototype through an attached symbol.
//

function ζ(a, b) {
    const custom = b[isProto];
    return a instanceof (custom ? custom : b);
}