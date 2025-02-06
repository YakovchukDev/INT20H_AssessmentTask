import {LoginScheme} from "./login.ts";
import {IsString, Length} from "class-validator";

export class SignupScheme extends LoginScheme{
    @IsString()
    @Length(3, 64)
    nickname: string;

    @IsString()
    @Length(3, 64)
    username: string;


    @IsString()
    confirmedPassword: string;
}