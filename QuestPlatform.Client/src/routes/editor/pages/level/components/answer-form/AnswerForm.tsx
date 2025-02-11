import {FC, useState} from "react";
import {Box, Stack, Typography} from "@mui/material";
import Selector from "../../../../../../lib/components/styled/Selector.tsx";
import * as styles from "./answer.styles.ts";
import WriteInput from "./components/write-input/WriteInput.tsx";
import GeolocationForm from "./components/geolocation-form/GeolocationForm.tsx";

const Variants = {
    Write : "Написати",
    Geolocation : "Геолокація"
}
const AnswerForm:FC = ()=>{
    const [variant, setVariant] = useState<string>(Object.values(Variants)[0]);

    return (
        <Stack gap={'20px'}>
            <Typography variant={'h6'}>Відповідь</Typography>
            <Box sx={styles.container}>
                {
                    variant === Variants.Write ? <WriteInput /> :
                    variant === Variants.Geolocation ? <GeolocationForm/> :
                    <></>
                }

            </Box>
            <Selector
                value={variant}
                onSelect={setVariant}
                variants={Object.values(Variants)}
            />
        </Stack>
    )
}

export default AnswerForm;