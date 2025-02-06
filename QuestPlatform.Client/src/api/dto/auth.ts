export type LoginDto = {
    email: string;
    password: string;
}
export type SignupDto = {
    email: string;
    password: string;
    nickname: string;
    username: string;

}
export type JwtTokenPayload = {
    token : string;
}
