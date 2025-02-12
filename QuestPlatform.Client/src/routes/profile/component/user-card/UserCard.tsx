import {FC} from "react";
import {Avatar, Box, Stack, Typography} from "@mui/material";
import * as styles from "../profile-form/profile.styles.ts";

const UserCard:FC = ()=>{
    return (
        <Box display={'flex'} justifyContent={'space-between'} gap={'15px'}>
            <Stack gap={'20px'}>
                <Avatar sx={styles.avatar}>
                    S
                </Avatar>
                <Stack gap={'5px'}>
                    <Typography fontSize={'1.3em'} variant={'body1'} fontWeight={'700'}>Lorem Ipsum</Typography>
                    <Typography color={'grey.800'}>@nagibator</Typography>
                    <Typography color={'grey.600'} variant={'body2'} sx={{maxWidth:"560px"}}>
                        Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis.
                    </Typography>
                </Stack>
            </Stack>
        </Box>
    )
}

export default UserCard;