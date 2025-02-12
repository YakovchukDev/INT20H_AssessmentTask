import {FC, ReactElement} from "react";
import {InputProps, Stack, Typography} from "@mui/material";
import { ValidationError } from "yup";

export type InputContainerProps = {
    children: ReactElement<InputProps>;
    error ?: ValidationError;
}
const InputContainer:FC<InputContainerProps> = ({
    children, error
})=>{
    return (
        <Stack>
            {children}
            {
                error &&
                <Typography color={'error'} variant={'body2'}>
                    {error.message}
                </Typography>
            }
        </Stack>
    )
}
export default InputContainer;