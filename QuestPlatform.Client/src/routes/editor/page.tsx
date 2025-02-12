import {FC} from "react";
import {Box} from "@mui/material";
import * as styles from "./editor.styles.ts";
import {Outlet} from "react-router";
import Panel from "./components/panel/Panel.tsx";

const EditorPage:FC = () => {
    return (
        <Box sx={styles.page}>
            <Box sx={styles.container}>
                <Box sx={styles.content}>
                    <Outlet/>
                </Box>
                <Box sx={styles.panel}>
                    <Panel/>
                </Box>
            </Box>
        </Box>
    )
}


export default EditorPage;