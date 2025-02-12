import {FC} from "react";
import {Box, Button, Stack, Typography} from "@mui/material";
import * as styles from "./level.styles.ts";
import TextInput from "../../../../lib/components/styled/Input.tsx";
import Select from "./components/select/Select.tsx";

const content = `
<h1>
 Lorem Ipsum is simply dummy text of the
</h1>
`
const LevelPage:FC = ()=>{
    const answerType:string = "select";
    const values = [
        "sosal",
        "net",
        "mdooo",
    ];

    return (
        <Box sx={styles.container}>
            <Typography dangerouslySetInnerHTML={{__html:content}} sx={styles.content}>
            </Typography>
            <Stack gap={'10px'} sx={{marginTop:'32px'}}>
                <Typography variant={'h6'} fontSize={"600"}>
                    Відповідь
                </Typography>
                {
                    answerType === "input" ? <TextInput name={"answer"}/> :
                    answerType === "select" ? <Select onlyOneCorrect={true} name={"answer"} values={values}/> :
                    <></>
                }
            </Stack>
            <Stack sx={{marginTop:'20px'}} direction={'row-reverse'}>
                <Button>Відповісти</Button>
            </Stack>

        </Box>

    )
}

export default LevelPage;