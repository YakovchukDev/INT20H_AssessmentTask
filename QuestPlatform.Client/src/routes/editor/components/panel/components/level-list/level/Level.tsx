import {createRef, FC} from "react";
import * as styles from "./level.styles.ts";
import {Box, IconButton, Typography} from "@mui/material";
import {LevelType} from "../../../../../../../types/quest.ts";
import {NavLink} from "react-router";
import {Delete} from "@mui/icons-material";


export type LevelProps = {
    level : LevelType;
    onDragStart ?: ()=>void;
    onDragEnd ?: ()=>void;
}
const Level:FC<LevelProps> = ({
    level,
    onDragStart, onDragEnd,
})=>{


    return (
        <Box
            onDragStart={onDragStart}
            onDragEnd={onDragEnd}
            sx={styles.container}
        >
            <NavLink to={`level/${level.pageNumber}`}>
                    <Typography variant={'subtitle1'}>
                        {level.title}
                    </Typography>
                </NavLink>
            <IconButton>
                <Delete sx={{fontSize:'0.8em'}} color={'primary'}/>
            </IconButton>
        </Box>
    )
}

export default Level;