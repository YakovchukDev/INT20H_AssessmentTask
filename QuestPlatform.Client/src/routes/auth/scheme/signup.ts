import {object, string, ref} from "yup";
import {PASSWORD_REGEXP} from "./index.ts";

const SignupScheme = object({
    email : string().email().required(),
    nickname : string().min(4).max(64).required(),
    username : string().min(4).max(64).required(),
    password : string().matches(PASSWORD_REGEXP).required(),
    confirmedPassword : string().oneOf([ref('password'), ""], "Password not confirmed").required(),
});

export default SignupScheme;