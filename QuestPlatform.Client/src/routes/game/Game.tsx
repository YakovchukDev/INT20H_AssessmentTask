import {FC, useState} from "react";
import {Box, Container} from "@mui/material";
import * as styles from "./game.styles.ts";
import Level from "./pages/level/Level.tsx";

const GamePage:FC = ()=>{
    const [levelIndex, setLevelIndex] = useState(0);

    return (
        <Box sx={styles.page}>
            <Container sx={styles.container}>
                <Level/>
            </Container>
        </Box>
    )
}

export default GamePage;