import {FC} from "react";
import {NavLink} from "react-router";
import * as styles from "./item.styles.ts";
import {Box, Typography} from "@mui/material";

export type NavbarProps = {
    to : string;
    name : string;
}
const NavbarItem:FC<NavbarProps> = ({to, name})=>{
    return (
        <NavLink to={to}>
            <Box sx={styles.container}>
                <Box sx={styles.content}>
                    <Typography sx={styles.name} variant={'subtitle1'}>{name}</Typography>
                </Box>
            </Box>
        </NavLink>
    )
}

export default NavbarItem;