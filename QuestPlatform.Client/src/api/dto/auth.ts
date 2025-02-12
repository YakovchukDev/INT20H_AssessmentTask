import {object, string, InferType} from "yup";

export type LoginDto = {
    email: string;
    password: string;
}
export type SignupDto = {
    email: string;
    password: string;
    confirmedPassword: string;
    nickname: string;
    username: string;
}
export const JwtTokenScheme = object({
    token : string().matches(/(^[\w-]*\.[\w-]*\.[\w-]*$)/).required(),
});
export type JwtTokenType = InferType<typeof JwtTokenScheme>;
