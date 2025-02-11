import * as styles from "./level.styles.ts";
import {FC} from "react";
import {Box, Stack, Typography} from "@mui/material";
import {useParams} from "react-router";
import Card from "../../../../lib/components/styled/Card.tsx";
import ReactQuill from "react-quill";
import AnswerForm from "./components/answer-form/AnswerForm.tsx";

const LevelPage:FC = ()=>{
    const params = useParams();
    const index = Number(params.index);

    return (
        <Card>
            <Box sx={styles.container}>
                <Box sx={styles.content}>
                    <Stack gap={'20px'}>
                        <Typography variant={'h6'}>
                            Вступ
                        </Typography>
                        {/*<ReactQuill/>*/}
                    </Stack>
                </Box>
                <Box sx={{marginTop:'20px'}}>
                    <AnswerForm/>
                </Box>
            </Box>
        </Card>

    )
}

export default LevelPage;