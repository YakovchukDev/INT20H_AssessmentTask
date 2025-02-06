import {FC} from "react";

const LoginPage:FC = ()=>{
    return (
        <div>
            Login
            <div>
                <input placeholder={"email"}/>
                <input placeholder={"password"}/>
            </div>
        </div>
    )
}

export default LoginPage;