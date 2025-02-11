import {FC} from "react";
import {Button, Stack, Typography} from "@mui/material";
import {LevelType} from "../../../../../../types/quest.ts";
import Level from "./level/Level.tsx";


export type LeveListProps = {
    levels : LevelType[];
}
const LevelList:FC<LeveListProps> = ({
    levels
})=>{
    return (
        <Stack gap={'10px'}>
            <Typography variant={'subtitle1'}>
                Рівні
            </Typography>
            <Stack gap={'5px'}>
                {
                    levels.map(level=>{
                        return (
                            <Level
                                key={level.id}
                                level={level}
                            />
                        )
                    })
                }
            </Stack>
            <Button>
                Новий Рівень
            </Button>
        </Stack>
    )
}

export default LevelList;