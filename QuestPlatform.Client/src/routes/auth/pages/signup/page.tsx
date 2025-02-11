import {FC, useState} from "react";
import {useNavigate} from "react-router";
import {Box, Button, Link, Stack, Typography} from "@mui/material";
import InputContainer from "../../components/InputContainer.tsx";
import {PasswordAuthInput} from "../../components/AuthInput.tsx";
import useAuthorize from "../../hooks/useAuthorize.ts";
import AuthApi from "../../../../api/auth.ts";
import SignupScheme from "../../scheme/signup.ts";
import {ValidationError} from "yup";
import * as styles from "./signup.styles.ts";
import TextInput from "../../../../lib/components/styled/Input.tsx";


const SignupPage:FC = () => {
    const navigate = useNavigate();
    const [currentErrors, setCurrentErrors] = useState<Map<string, ValidationError>>(new Map());

    const signup = useAuthorize(
        AuthApi.signup,
        SignupScheme,
        (user)=>{
            navigate(`/profile/${user.id}`);
        },
        (errors:ValidationError[])=>{
            const mappedErrors = new Map(errors.map(error=>{
                return [error.path ?? '', error];
            }));
            setCurrentErrors(mappedErrors);
        },
    );


    const onSubmit = async (ev:any)=>{
        ev.preventDefault();
        const event = ev.nativeEvent;
        const data = new FormData(event.target);
        await signup(data);
    }
    return (
        <form onSubmit={onSubmit}>
            <Box sx={styles.container}>
                <Stack gap={'15px'}>
                    <Box sx={styles.inputColumn}>
                        <InputContainer error={currentErrors.get("username")}>
                            <TextInput name={"username"} placeholder={'username'}/>
                        </InputContainer>
                        <InputContainer error={currentErrors.get("nickname")}>
                            <TextInput name={"nickname"} placeholder={'nickname'}/>
                        </InputContainer>
                    </Box>
                    <InputContainer error={currentErrors.get("email")}>
                        <TextInput name={"email"} placeholder={'email'}/>
                    </InputContainer>
                    <InputContainer error={currentErrors.get("password")}>
                        <PasswordAuthInput name={"password"} placeholder={'password'}/>
                    </InputContainer>
                    <InputContainer error={currentErrors.get("confirmedPassword")}>
                        <PasswordAuthInput name={"confirmedPassword"} placeholder={'confirmed password'}/>
                    </InputContainer>

                </Stack>
                <Stack gap={'10px'} sx={styles.bottom}>
                    <Button type={'submit'} sx={styles.submit} variant={'contained'}>
                        Зареєструватися
                    </Button>
                    <Link href={'/login'}>
                        <Typography  variant={'body2'} color={'info'}>Вже є акаунт?</Typography>
                    </Link>
                </Stack>
            </Box>
        </form>
    )
}
export default SignupPage;