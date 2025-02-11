import {FC, useState} from "react";
import FormCard from "../form-card/FormCard.tsx";
import Question from '@mui/icons-material/QuestionMark';
import PsychologyIcon from '@mui/icons-material/Psychology';
import {Rating, SxProps, Theme} from "@mui/material";


const icon:SxProps<Theme> = {
    fontSize : '32px',
}
const DifficultyInput:FC = ()=>{
    const [value, setValue] = useState<number>(2);

    const onChange = (_ev:any, newValue:number)=>{
        setValue(newValue);
    }
    return (
        <FormCard
            icon={Question}
            title={'Складність'}
            subtitle={'Обмежити квест за часом. Відлік починається, коли учасник розпочинає (на паузу поставити неможливо). По завершенню відліку квест примусово завершується й підсумовується результат, який учасник встиг досягти.\n'}>

            <Rating
                onChange={onChange}
                value={value}
                name={'difficulty'}
                icon={<PsychologyIcon sx={icon}/>}
                emptyIcon={<PsychologyIcon sx={icon}/>}
            />
        </FormCard>
    )
}

export default DifficultyInput;