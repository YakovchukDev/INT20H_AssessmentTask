import {FC} from "react";
import {Box, Button, Stack} from "@mui/material";
import * as styles from "./preview.styles.ts";
import QuestCard from "../../../../layout/quest-card/component/card/QuestCard.tsx";


const PreviewPage:FC = ()=>{
    return (
        <Box sx={styles.container}>
            <Stack>
                <QuestCard/>
                <Box sx={styles.content}>
                    <Stack gap={'10px'} alignItems={'flex-start'}>
                        <Box dangerouslySetInnerHTML={{__html : `<h1>lorem ipsum</h1>`}}/>
                        <Box sx={{
                            width:'100%', display:'flex', justifyContent:'flex-end'
                        }}>
                            <Button>
                                Почати
                            </Button>
                        </Box>

                    </Stack>
                </Box>

            </Stack>
        </Box>
    )
}

export default PreviewPage;