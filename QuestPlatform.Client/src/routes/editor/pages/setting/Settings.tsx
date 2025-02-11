import {FC} from "react";
import {Box, Button, Stack, Typography} from "@mui/material";
import * as styles from "./settings.styles.ts";
import NameInput from "./components/name-input/NameInput.tsx";
import DescriptionInput from "./components/description-input/DescriptionInput.tsx";
import TimeSelector from "./components/time-selector/TimeSelector.tsx";
import CommandInput from "./components/command-input/CommandInput.tsx";
import DifficultyInput from "./components/difficulty-input/DiffucultyInput.tsx";
import CategoryInput from "./components/category/Category.tsx";
import TagsInput from "./components/tag-input/TagInput.tsx";
import Card from "../../../../lib/components/styled/Card.tsx";


const SettingsPage:FC = () => {
    const onSubmit = (ev:any)=> {
        ev.preventDefault();
        const event = ev.nativeEvent;
        const formData= new FormData(event.target);
        const dto = Object.fromEntries(formData);
        console.log(dto);
    }
    return (
        <Card>
            <form onSubmit={onSubmit}>
                <Box sx={styles.container}>
                    <Box sx={styles.header}>
                        <Typography fontWeight={'500'} variant={'h5'}>
                            Налаштування
                        </Typography>
                    </Box>
                    <Stack sx={styles.content} gap={'20px'}>
                        <NameInput/>
                        <DescriptionInput/>
                        <TimeSelector/>
                        <CommandInput/>
                        <DifficultyInput/>
                        <CategoryInput/>
                        <TagsInput/>
                    </Stack>
                    <Button type={'submit'} sx={styles.submit}>
                        Зберегти змінни
                    </Button>
                </Box>
            </form>
        </Card>

    )
}


export default SettingsPage;