import { object, string } from 'yup';
import {PASSWORD_REGEXP} from "./index.ts";

const LoginScheme = object({
    email : string().email().required(),
    password : string().matches(PASSWORD_REGEXP).required(),
});

export default LoginScheme;