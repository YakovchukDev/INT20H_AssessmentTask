import {FC, useState} from "react";
import FormCard from "../form-card/FormCard.tsx";
import TextInput from "../../../../../../lib/components/styled/Input.tsx";
import {Button, Stack} from "@mui/material";

const NameInput:FC = ()=>{
    const [value, setValue] = useState('My Quest');

    const onChange = (ev)=>{
        const event = ev.nativeEvent as InputEvent;
        const target = event.target as HTMLInputElement;
        setValue(target.value);
    }
    return (
        <FormCard alwaysExpand title={"Ім'я"}>
            <Stack alignItems={'flex-start'} gap={'15px'}>
                <TextInput
                    name={'title'}
                    onChange={onChange}
                    sx={{width:'100%', borderColor:'grey.400'}}
                    value={value}
                />

            </Stack>

        </FormCard>
    )
}

export default NameInput;