// import api from "./index.ts";
import {JwtTokenPayload, LoginDto, SignupDto} from "./dto/auth.ts";

export const AUTH_TOKEN = "auth-token";
const AuthApi = {
    async login(dto:LoginDto):Promise<JwtTokenPayload> {
        return {
            token : "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MCwibmlja25hbWUiOiJzdXMiLCJlbWFpbCI6InN1c0BnbWFpbC5jb20iLCJpYXQiOjE1MTYyMzkwMjJ9.dVP7cv6Xb7FDZ0AJ6RuC3_JL0DEgS-fAFDZFmi5oEcg",
        }
    },
    async signup(dto:SignupDto):Promise<JwtTokenPayload> {
        return {
            token : "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MCwibmlja25hbWUiOiJzdXMiLCJlbWFpbCI6InN1c0BnbWFpbC5jb20iLCJpYXQiOjE1MTYyMzkwMjJ9.dVP7cv6Xb7FDZ0AJ6RuC3_JL0DEgS-fAFDZFmi5oEcg",
        }
    }
}

export default AuthApi;