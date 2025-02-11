import {FC} from "react";
import * as styles from "./navbar.styles.ts";
import {Box, Button, Container, Stack, Typography} from "@mui/material";
import NavbarItem, {NavbarProps} from "./components/item.tsx";


const ITEMS:NavbarProps[] = [
    {
        to : '/',
        name : 'Головна',
    },
    {
        to : '/profile',
        name : 'Профіль',
    },
    {
        to : '/browse',
        name : 'Пошук',
    },
]
const Navbar:FC = ()=>{
    return (
        <Box sx={styles.container}>
            <Container sx={styles.content}>
                <Box sx={styles.left}>
                    <Typography>
                        <Typography fontWeight={'700'} variant={'h5'} color={'info'} component={'span'}>IQ</Typography>
                        <Typography fontWeight={'700'} variant={'h5'} component={'span'}>uest</Typography>
                    </Typography>
                </Box>
                <Box sx={styles.right}>
                    <Stack direction={'row'}>
                        {
                            ITEMS.map(item=>{
                                return (
                                    <NavbarItem name={item.name} to={item.to}/>
                                )
                            })
                        }
                    </Stack>
                    <Button variant={'outlined'} sx={{marginLeft:'20px'}}>
                        Мої квести
                    </Button>
                </Box>
            </Container>

        </Box>
    )
}

export default Navbar;