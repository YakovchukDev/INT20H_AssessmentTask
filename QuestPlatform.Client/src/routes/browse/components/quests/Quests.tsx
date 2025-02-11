import {FC} from "react";
import Card from "../../../../lib/components/styled/Card.tsx";
import {Box, Typography} from "@mui/material";
import * as styles from "./quests.styles.ts";
import QuestCard from "../../../../layout/quest-card/component/card/QuestCard.tsx";

const QuestsList:FC = ()=>{
    return (
        <Card sx={{padding:'20px'}}>
            <Typography variant={'h6'}>Усі Квести</Typography>
            <Box sx={styles.list}>
                <QuestCard href={"/quest/0"}/>
            </Box>
        </Card>
    )
}

export default QuestsList;