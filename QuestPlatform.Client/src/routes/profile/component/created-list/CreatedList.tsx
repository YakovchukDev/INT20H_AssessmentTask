import {FC} from "react";
import Card from "../../../../lib/components/styled/Card.tsx";
import {Box, Button, IconButton, Stack, Typography} from "@mui/material";
import QuestCard from "../../../../layout/quest-card/component/card/QuestCard.tsx";
import * as styles from "./quest.styles.ts";
import CloseIcon from '@mui/icons-material/Close';

const QuestItem:FC = ()=>{
    return (
        <Box sx={styles.item}>
            <QuestCard href={"/editor/1"}/>
            <Stack gap={'20px'} direction={'column'}  justifyContent={'center'}>
                <IconButton>
                    <CloseIcon color={'primary'}/>
                </IconButton>
            </Stack>
        </Box>
    )
}
const CreatedList:FC = ()=>{

    return (

        <Card sx={{padding:"20px"}}>
            <Typography variant={"h6"}>Створенні</Typography>
            <Stack sx={{marginTop:'20px'}} gap={'10px'}>
                <QuestItem/>
                <QuestItem/>
            </Stack>
            <Button sx={{marginTop:"20px", padding:"10px"}}>
                Створити новий квест
            </Button>
        </Card>
    )
}

export default CreatedList;