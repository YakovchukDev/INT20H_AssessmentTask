import {FC, useState} from "react";
import FormCard from "../form-card/FormCard.tsx";
import PeopleAltIcon from '@mui/icons-material/PeopleAlt';
import Selector from "../../../../../../lib/components/styled/Selector.tsx";
import {Stack} from "@mui/material";
import CustomInput from "../custom-input/CustomInput.tsx";

const VARIANTS = [
    "Без Команд",
    "2",
    "3",
    "4",
    "5",
];
const CommandInput:FC = ()=>{
    const [value, setValue] = useState<string>(
        VARIANTS[0]
    );

    return (
        <FormCard
            icon={PeopleAltIcon}
            title={'Команди'}
            subtitle={'Організувати командне змагання (кожний учасник команди може приєднатись зі свого пристрою). Для команд на кожному рівні можна давати завдання однакові або різні.'}
        >
            <input onChange={()=>{}} style={{display:"none"}} name={"commands"} value={value}/>

            <Stack alignItems={'flex-start'} gap={'10px'}>
                <Selector value={value} onSelect={setValue} name={"commands"} variants={VARIANTS}/>
                <CustomInput onSubmit={setValue} title={'Вкажіть кількість команд.'}/>
            </Stack>

        </FormCard>
    )
}

export default CommandInput;