// Stoasy (Synchronous to asynchronous)
// Copyright (c) 2020, Siemens AG
//
// Author: Roland Eckl, DI ST PI AP
//
// Ensures proper value assignment with different operators.
//

async function 𝜀(member, identifier, operator, value) {
    let nvalue = value;
    if(operator != '='){
        let current = await α(member[identifier], true);
        switch(operator){
            case '+=':
                nvalue = current += value;
                break;
            case '-=':
                nvalue = current -= value;
                break;
            case '*=':
                nvalue = current *= value;
                break;
            case '/=':
                nvalue = current /= value;
                break;
            case '%=':
                nvalue = current %= value;
                break;
            case '**=':
                nvalue = current **= value;
                break;
            case '>>=':
                nvalue = current >>= value;
                break;
            case '<<=':
                nvalue = current <<= value;
                break;
            case '>>>=':
                nvalue = current >>>= value;
                break;
            case '&=':
                nvalue = current &= value;
                break;
            case '^=':
                nvalue = current ^= value;
                break;
            case '|=':
                nvalue = current |= value;
                break;
            default: // unknown operator
                throw 'Unknown operator';
        }
    }
    await α(member[identifier] = nvalue);
    return nvalue;
}
