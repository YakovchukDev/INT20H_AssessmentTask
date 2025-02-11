import {FC} from "react";
import Card from "../../../../lib/components/styled/Card.tsx";
import {Stack, Typography} from "@mui/material";
import QuestCard from "../../../../layout/quest-card/component/card/QuestCard.tsx";


const CompletedList:FC = ()=>{
    return (
        <Card sx={{padding:"20px"}}>
            <Typography variant={'h6'}>
                Пройдені квести
            </Typography>
            <Stack sx={{marginTop:"20px"}} gap={'10px'}>
                <QuestCard href={"/quest/0"}/>
            </Stack>
        </Card>
    )
}

export default CompletedList;