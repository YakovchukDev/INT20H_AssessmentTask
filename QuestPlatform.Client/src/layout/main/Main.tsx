import {FC} from "react";
import {Box} from "@mui/material";
import * as styles from "./main.styles.ts";
import {Outlet} from "react-router";
import Navbar from "../navbar/Navbar.tsx";

const MainLayout:FC = ()=>{
    return (
        <Box sx={styles.page}>
            <Navbar/>
            <Box sx={styles.content}>
                <Outlet/>
            </Box>
        </Box>
    )
}

export default MainLayout;