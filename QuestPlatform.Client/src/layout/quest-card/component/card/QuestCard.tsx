import {FC} from "react";
import {Box, Rating, Stack, SxProps, Theme, Typography} from "@mui/material";
import * as styles from "./preview.styles.ts";
import TagElement from "../tag/Tag.tsx";
import TimeIcon from '@mui/icons-material/AccessTimeFilled';
import CategoryIcon from "@mui/icons-material/Category";
import PsychologyIcon from '@mui/icons-material/Psychology';
import PeopleIcon from '@mui/icons-material/People';
import {useNavigate} from "react-router";

export type QuestCardProps = {
    href ?: string;
    zoomed ?: boolean;
    scale ?: number;
    renderTags ?: boolean;

}
const QuestCard:FC<QuestCardProps> = ({href, zoomed=true, scale=1, renderTags=true})=>{
    const navigate = useNavigate();

    const goTo = ()=>{
        if (href) {
            navigate(href);
        }
    }

    const res:SxProps<Theme> = {
        width : 700 * scale,
        height : 393 * scale,
    }

    return (
        <Box onClick={goTo} sx={[styles.container, zoomed ? styles.zoomed : undefined, res]}>
            <Box sx={styles.content}>
                <Stack gap={'5px'}>
                    <Typography
                        variant={'body1'}
                        fontSize={'2em'}
                        fontWeight={'700'}
                    >Назва Квесту</Typography>
                    <Typography>
                        Підзаголовок
                    </Typography>
                </Stack>
                {
                    renderTags &&
                    <Stack alignItems={'flex-start'} gap={'5px'}>
                        <TagElement value={""}>
                            <Rating emptyIcon={<PsychologyIcon/>} color={'primary.main'} icon={<PsychologyIcon color={'primary'}/>} readOnly value={3}/>
                        </TagElement>
                        <TagElement value={"Ігри"}>
                            <CategoryIcon/>
                        </TagElement>
                        <TagElement value={"60хв"}>
                            <TimeIcon/>
                        </TagElement>
                        <TagElement value={"1"}>
                            <PeopleIcon/>
                        </TagElement>
                    </Stack>
                }
            </Box>
            <Box className={'wallpaper'} sx={styles.wallpaper}/>
        </Box>
    )
}

export default QuestCard;