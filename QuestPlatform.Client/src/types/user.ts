export type User = {
    id : number;
    username : string;
    nickname : string;
    aboutMe : string;
    email : string;
    password: string;
}
export type JwtUser = {
    id : number;
    nickname : string;
    email : string;
    password: string;
}