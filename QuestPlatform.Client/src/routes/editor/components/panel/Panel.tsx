import {FC} from "react";
import Card from "../../../../lib/components/styled/Card.tsx";
import * as styles from "./panel.styles.ts";
import {Box, Button, Stack, Typography} from "@mui/material";
import LevelList from "./components/level-list/LeveList.tsx";
import {NavLink} from "react-router";
import VisibilityIcon from '@mui/icons-material/Visibility';
import SettingsIcon from '@mui/icons-material/Settings';
import BarChartIcon from '@mui/icons-material/BarChart';
import ShareIcon from '@mui/icons-material/Share';

const Panel:FC = ()=>{

    return (
        <Card sx={styles.container}>
            <Stack gap={'10px'}>
                <Typography variant={'subtitle1'}>
                    My Quest
                </Typography>
                <Box sx={styles.links}>
                    <NavLink to={'view'}>
                        <Button>
                            <VisibilityIcon/>
                        </Button>
                    </NavLink>
                    <NavLink to={''}>
                        <Button>
                            <SettingsIcon/>
                        </Button>
                    </NavLink>
                    <NavLink to={'stats'}>
                        <Button>
                            <BarChartIcon/>
                        </Button>
                    </NavLink>
                    <NavLink to={'share'}>
                        <Button>
                            <ShareIcon/>
                        </Button>
                    </NavLink>
                </Box>
            </Stack>
            <Box sx={{marginTop:"20px"}}>
                <LevelList  levels={[
                    {
                        id: 0,
                        title : 'Вступ',
                        pageNumber: 1,
                    },
                    {
                        id : 1,
                        title : 'Deep dark dungeon',
                        pageNumber : 2,
                    },
                    {
                        id : 2,
                        title : 'Зря я сюда полез...',
                        pageNumber : 3,
                    },
                    {
                        id : 3,
                        title : 'Это конец?!',
                        pageNumber : 4,
                    }
                ]}/>
            </Box>
        </Card>
    )
}

export default Panel;