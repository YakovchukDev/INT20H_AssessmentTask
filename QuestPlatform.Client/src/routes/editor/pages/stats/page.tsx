import * as styles from "./stats.styles.ts";
import {FC} from "react";
import Card from "../../../../lib/components/styled/Card.tsx";
import {Box, Typography} from "@mui/material";
import InfoCard from "./component/info-card/InfoCard.tsx";

const StaticsPage:FC = ()=>{
    return (
        <Card sx={styles.container}>
            <Box>
                <Typography fontWeight={'600'} variant={'h6'}>Статистика</Typography>
                <Box sx={styles.list}>
                    <InfoCard name={"Команди"}/>
                    <InfoCard name={"Успіхи"}/>
                    <InfoCard name={"Середній час"}/>
                    <InfoCard name={"Помилки"}/>
                    <InfoCard name={"Рекорди"}/>

                </Box>
            </Box>
            <Box sx={{marginTop:'32px'}}>
                <Typography fontWeight={'600'} variant={'h6'}>Історія</Typography>
            </Box>

        </Card>
    )
}

export default StaticsPage;