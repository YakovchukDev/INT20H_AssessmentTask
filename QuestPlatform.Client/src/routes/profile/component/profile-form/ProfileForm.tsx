import {FC} from "react";
import Card from "../../../../lib/components/styled/Card.tsx";
import * as styles from "./profile.styles.ts";
import {Box, Button, Stack, Typography} from "@mui/material";
import {NavLink, useSearchParams} from "react-router";
import CreateIcon from '@mui/icons-material/Create';
import UserCard from "../user-card/UserCard.tsx";

type OptionProps = {
    name : string;
    count : number;
    view : string;
}
const Option:FC<OptionProps> = ({
    name, view, count
})=>{
    const [params, _] = useSearchParams();
    const currentView = params.get("view");

    const isActive = currentView === view;

    return (
        <NavLink to={`?view=${view}`}>
            <Box sx={[styles.option, isActive ? styles.active : undefined]}>
                <Typography variant={'subtitle1'}>
                    {name}
                </Typography>
                <Typography fontSize={'0.8em'} sx={styles.circle}>
                    {count}
                </Typography>
            </Box>
        </NavLink>
    )
}
const ProfileForm:FC = ()=>{
    return (
        <Card sx={{padding:'20px 20px 0 20px'}}>
            <UserCard/>
            <Box sx={{marginTop:'20px'}} display={'flex'} justifyContent={'space-between'} alignItems={'center'}>
                <Box>
                    <Stack direction={'row'}>
                        <Option view={'completed'} count={0} name={"Пройдені квести"}/>
                        <Option view={'created'} count={0} name={"Мої квести"}/>
                    </Stack>
                </Box>
                <Box>
                    <Button sx={{display:'flex', gap:'10px'}}>
                        <CreateIcon sx={{fontSize:'1em'}}/> Редагувати профіль
                    </Button>
                </Box>
            </Box>
        </Card>
    )
}


export default ProfileForm;