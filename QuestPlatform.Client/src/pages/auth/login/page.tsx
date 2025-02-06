import styles from "./login.module.sass";
import {FC} from "react";
import AuthApi from "../../../api/auth.ts";
import {LoginScheme} from "../sceme/login.ts";
import useAuth from "../hooks/useAuth.ts";
import {useNavigate} from "react-router";


const LoginPage:FC = ()=>{
    const navigate = useNavigate();

    const login = useAuth(
        AuthApi.login,
        LoginScheme,
        {
            onSuccess : (dto)=>{
                console.log(dto);
                navigate("/profile");
            },
            onError : (err)=>{
                const values = err.constraints ? Object.values(err.constraints) : "undefined error";
                alert(values[0]);
            }
        }
    )

    const onSubmit = async (ev)=>{
        ev.preventDefault();
        const event = ev.nativeEvent;
        const formData = new FormData(event.target);
        login(formData);
    }

    return (
        <form onSubmit={onSubmit}>
            <div className={styles.container}>
                <h1 className={styles.title}>
                    Login
                </h1>
                <div className={styles.inputs}>
                    <input
                        placeholder={"email"}
                        name={"email"}
                    />
                    <input
                        placeholder={"password"}
                        name={"password"}
                    />
                </div>
                <div className={styles.bottom}>
                    <button
                        type={"submit"}
                        className={styles.button}>
                    Login</button>
                </div>
            </div>
        </form>

    )
}

export default LoginPage;