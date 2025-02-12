import {FC, useEffect, useState} from "react";
import FormCard from "../form-card/FormCard.tsx";
import Selector from "../../../../../../lib/components/styled/Selector.tsx";
import TimerIcon from '@mui/icons-material/Timer';
import CustomInput from "../custom-input/CustomInput.tsx";
import {Box} from "@mui/material";

const DEFAULT_TIMES = ["без ліміту", "30хв", "60хв", "90хв", "120хв"];

const TimeSelector:FC = ()=>{
    const [value, setValue] = useState<string>(
        DEFAULT_TIMES[1],
    );

    useEffect(()=>{
    }, []);

    return (
        <FormCard
            icon={TimerIcon}
            title={'Загальний ліміт часу'}
            subtitle={'Обмежити квест за часом. Відлік починається, коли учасник розпочинає (на паузу поставити неможливо). По завершенню відліку квест примусово завершується й підсумовується результат, який учасник встиг досягти.\n'}>
            <input onChange={()=>{}} style={{display:"none"}} name={"time"} value={value}/>
            <Selector
                onSelect={setValue}
                value={value}
                variants={DEFAULT_TIMES}
            />
            <Box sx={{marginTop:'10px'}}>
                <CustomInput
                    title={"Вкажіть власне значення в хвилинах."}
                    onSubmit={setValue}
                />
            </Box>
        </FormCard>
    )
}

export default TimeSelector;