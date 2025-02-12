import {FC, ReactNode} from "react";
import {Box, Typography} from "@mui/material";
import * as styles from "./info.styles.ts";

export type InfoCardProps = {
    name : string;
    children?: ReactNode;
}
const InfoCard:FC<InfoCardProps> = ({
    name, children
})=>{
    return (
        <Box sx={styles.container}>
            <Typography textAlign={'center'} alignSelf={'center'} variant={'subtitle1'}>{name}</Typography>
            <Box sx={styles.content}>
                {children}
            </Box>
        </Box>
    )
}

export default InfoCard;