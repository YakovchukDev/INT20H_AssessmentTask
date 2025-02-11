export interface IClass<T extends object> {
    new(...args: any[]): T;
}

export const objectToClass = <T extends object>(obj:T, c:IClass<T>)=>{
    const res = new c();
    const keys = Object.keys(obj) as (keyof T)[];
    for (const key of keys) {
        res[key] = obj[key];
    }
    return res;
}