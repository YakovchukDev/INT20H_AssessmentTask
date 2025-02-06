import {IClass, objectToClass} from "../../../utils/classObj.ts";
import {validate, ValidationError} from "class-validator";
import {JwtTokenPayload} from "../../../api/dto/auth.ts";
import {AUTH_TOKEN} from "../../../api/auth.ts";

type AuthMethod<T> = (dto:T)=>Promise<JwtTokenPayload>;

const useAuth = <T, S extends object>(
    authMethod:AuthMethod<T>,
    schemeClass:IClass<S>,
    options : {
        schemeConvertor ?: (scheme:S)=>T,
        onSuccess?: (payload:JwtTokenPayload) => void,
        onError?: (error:ValidationError) => void,
        additionValidator ?: (scheme:S)=>ValidationError|undefined,
    },
)=>{
    return async (data:FormData)=>{
        const scheme = objectToClass(
            Object.fromEntries(data) as object, schemeClass
        ) as S;
        const errors = await validate(scheme);

        if (options.additionValidator){
            const err = options.additionValidator(scheme);
            if (err) errors.push(err);
        }

        if (errors.length === 0) {
            const dto = options.schemeConvertor ? options.schemeConvertor(scheme) : (scheme as unknown) as T;
            const res = await authMethod(dto);
            localStorage.setItem(AUTH_TOKEN, res.token);
            options.onSuccess?.(res);
        } else {
            if (options.onError){
                const err = errors[0];
                options.onError(err);
            }
        }
    }
}

export default useAuth;