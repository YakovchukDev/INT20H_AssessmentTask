import {FC} from "react";
import {Box} from "@mui/material";
import * as styles from "./browse.styles.ts";
import QuestsList from "./components/quests/Quests.tsx";
import SearchForm from "./components/search-form/Search.tsx";


const BrowsePage:FC = ()=>{
    return (
        <Box sx={styles.container}>
            <Box sx={styles.content}>
                <SearchForm/>
                <QuestsList/>
            </Box>
        </Box>
    )
}

export default BrowsePage;