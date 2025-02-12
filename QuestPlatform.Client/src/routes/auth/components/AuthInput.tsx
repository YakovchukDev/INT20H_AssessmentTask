import {IconButton, Input, InputProps, styled} from "@mui/material";
import {FC, useState} from "react";
import VisibilityOffIcon from '@mui/icons-material/VisibilityOff';
import VisibilityIcon from '@mui/icons-material/Visibility';
import TextInput from "../../../lib/components/styled/Input.tsx";



export const PasswordAuthInput:FC<InputProps> = (props)=>{
    const [hidden, setHidden] = useState<boolean>(true);

    const inputType = hidden ? 'password' : 'text';
    const Icon = hidden ? VisibilityOffIcon : VisibilityIcon;

    const changeHidden = ()=>{
        setHidden((prev)=>!prev);
    }
    return (
        <TextInput
            endAdornment={
             <IconButton onClick={changeHidden} sx={{
                 padding : '5px',
             }}>
                <Icon color={'primary'} sx={{
                    width :'19px',
                    height : '19px',
                }} />
             </IconButton>
            }
            {...props}
            type={inputType}
        />
    )
}
