import {ObjectSchema, ValidationError} from "yup";
import {JwtTokenType} from "../../../api/dto/auth.ts";
import {AuthToken} from "../../../lib/constants/auth.ts";
import {JwtUser} from "../../../types/user.ts";
import {jwtDecode} from "jwt-decode";

type AuthMethod<T> = (dto:T)=>Promise<JwtTokenType>;
const useAuthorize = <T extends object>(
    authMethod:AuthMethod<T>,
    schema:ObjectSchema<T>,
    onSuccess : (user:JwtUser)=>void,
    onFailed ?: (err:ValidationError[])=>void,

)=>{
    return async (data:FormData)=>{
        const dto = Object.fromEntries(data) as T;
        try {
            schema.validateSync(dto, {
                abortEarly: false,
            });
            const res = await authMethod(dto);
            localStorage.setItem(AuthToken.AccessToken, res.token);
            const jwtUser:JwtUser = jwtDecode(res.token);
            onSuccess(jwtUser);

        } catch(e){
            const err = e as ValidationError;
            const errors = err.inner;
            onFailed?.(errors);
        }


    }
}

export default useAuthorize;