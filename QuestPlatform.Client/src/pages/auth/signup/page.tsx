import styles from "./signup.module.sass";
import {FC} from "react";
import {ValidationError} from "class-validator";
import AuthApi from "../../../api/auth.ts";
import useAuth from "../hooks/useAuth.ts";
import {useNavigate} from "react-router";
import {SignupScheme} from "../sceme/signup.ts";

const SignupPage:FC = () => {
    const navigate = useNavigate();

    const signup = useAuth(
        AuthApi.signup,
        SignupScheme,
        {
            onSuccess : (dto)=>{
                console.log(dto);
                navigate("/profile");
            },
            onError : (err)=>{
                const values = err.constraints ? Object.values(err.constraints) : "undefined error";
                alert(values[0]);
            },
            additionValidator : (scheme)=>{
                if (scheme.confirmedPassword !== scheme.password){
                    const err:ValidationError = {
                        property : "confirmedPassword",
                        constraints : {
                            "confirmed" : "password not confirmed",
                        }
                    }
                    return err;
                }
                return undefined;
            },
        }
    )

    const onSubmit = async (ev)=>{
        ev.preventDefault();
        const event = ev.nativeEvent;
        const formData = new FormData(event.target);
        signup(formData);
    }

    return (
        <form onSubmit={onSubmit}>
            <div className={styles.container}>
                <h1 className={styles.title}>
                    Signup
                </h1>
                <div className={styles.inputs}>
                    <input
                        placeholder={"email"}
                        name={"email"}
                    />
                    <input
                        placeholder={"username"}
                        name={"username"}
                    />
                    <input
                        placeholder={"nickname"}
                        name={"nickname"}
                    />
                    <input
                        placeholder={"password"}
                        name={"password"}
                    />
                    <input
                        placeholder={"confirm password"}
                        name={"confirmedPassword"}
                    />
                </div>
                <div className={styles.bottom}>
                    <button
                        type={"submit"}
                        className={styles.button}>
                        Signup</button>
                </div>
            </div>
        </form>
    )
}
export default SignupPage;