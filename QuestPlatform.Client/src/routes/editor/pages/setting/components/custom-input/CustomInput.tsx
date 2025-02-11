import {createRef, FC, useState} from "react";
import {Button, Fade, Stack, Typography} from "@mui/material";
import TextInput from "../../../../../../lib/components/styled/Input.tsx";
import TuneIcon from '@mui/icons-material/Tune';

export type CustomInputProps = {
    title : string;
    onSubmit ?: (value:string)=>void;
}
const CustomInput:FC<CustomInputProps> = ({
    title, onSubmit
})=>{
    const [visible, setVisible] = useState<boolean>(false);
    const inputRef = createRef<HTMLInputElement>();

    const changeVisibility = ()=>{
        setVisible((prev)=>!prev);
    }

    const emitSubmit = ()=>{
        if (inputRef.current){
            onSubmit?.(inputRef.current.value);
        }
    }

    return (
        <Stack gap={'10px'}>
            <Typography
                gap={'10px'} sx={{cursor:'pointer'}}
                display={'flex'} alignItems={'center'}
                onClick={changeVisibility} variant={'subtitle2'} color={'info'}>
                <TuneIcon/>
                Власне значення
            </Typography>
            <Fade in={visible}>
                <Stack gap={'5px'} display={visible ? 'flex' : 'none'}>
                    <Typography variant={'subtitle2'}>{title}</Typography>
                    <Stack gap={'15px'} direction={'row'}>
                        <TextInput
                            inputRef={inputRef}
                            sx={{width:'128px', padding:'5px'}}
                            inputProps={{max:"200", min:"1"}} type={'number'}/>
                        <Button
                            onClick={emitSubmit}
                            variant={'contained'}>Підтвердити</Button>
                    </Stack>
                </Stack>
            </Fade>
        </Stack>
    )
}

export default CustomInput;