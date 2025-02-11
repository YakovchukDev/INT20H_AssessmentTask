import {FC} from "react";
import {Box, Typography} from "@mui/material";
import * as styles from "./tag.styles.ts";

export type TagProps = {
    value : string;
    children?: React.ReactNode;
}
const TagElement:FC<TagProps> = ({
    value, children
})=>{

    return (
        <Box sx={styles.container}>
            {children}
            <Typography sx={styles.text} fontWeight={'700'} variant={'body2'}>{value}</Typography>
        </Box>
    )
}

export default TagElement;