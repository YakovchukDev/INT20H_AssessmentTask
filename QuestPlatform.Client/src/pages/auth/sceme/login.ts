import {IsEmail, Matches} from "class-validator";
import {PASSWORD_REGEXP} from "./index.ts";

export class LoginScheme {
    @IsEmail({}, {
        message : "Email does not match",
    })
    email: string;

    @Matches(PASSWORD_REGEXP, {
        message : "Password must have at least 6 characters, letter, uppercase and digit",
    })
    password: string;
}
