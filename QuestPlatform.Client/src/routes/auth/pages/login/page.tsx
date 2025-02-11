import {FC, useState} from "react";
import {Box, Button, Link, Stack, Typography} from "@mui/material";
import * as styles from "./login.styles.ts";
import {PasswordAuthInput} from "../../components/AuthInput.tsx";
import useAuthorize from "../../hooks/useAuthorize.ts";
import AuthApi from "../../../../api/auth.ts";
import LoginScheme from "../../scheme/login.ts";
import {useNavigate} from "react-router";
import InputContainer from "../../components/InputContainer.tsx";
import {ValidationError} from "yup";
import TextInput from "../../../../lib/components/styled/Input.tsx";

const LoginPage:FC = ()=>{
    const navigate = useNavigate();
    const [currentErrors, setCurrentErrors] = useState<Map<string, ValidationError>>(new Map());

    const login = useAuthorize(
        AuthApi.login,
        LoginScheme,
        (user)=>{
            navigate(`/profile/${user.id}`);
        },
        (errors)=>{
            const mappedErrors = new Map(errors.map(error=>{
                return [error.path ?? '', error];
            }));
            setCurrentErrors(mappedErrors);
        }
    );

    const onSubmit = async (ev:any)=>{
        ev.preventDefault();
        const nativeEvent = ev.nativeEvent;
        const data = new FormData(nativeEvent.target);
        await login(data);
    }

    return (
        <form onSubmit={onSubmit}>
            <Box sx={styles.container}>
                <Stack gap={'15px'}>
                    <InputContainer error={currentErrors.get("email")}>
                        <TextInput name={"email"} placeholder={'email'}/>
                    </InputContainer>
                    <InputContainer error={currentErrors.get("password")}>
                        <PasswordAuthInput name={"password"} placeholder={'password'}/>
                    </InputContainer>
                </Stack>
                <Stack gap={'10px'} sx={styles.bottom}>
                    <Button type={'submit'} sx={styles.submit} variant={'contained'}>
                        Увійти
                    </Button>
                    <Link href={'/signup'}>
                        <Typography  variant={'body2'} color={'info'}>Ще не маєте акаунту?</Typography>
                    </Link>
                </Stack>
            </Box>
        </form>

    )
}

export default LoginPage;