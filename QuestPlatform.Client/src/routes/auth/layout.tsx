import * as styles from "./auth.styles.ts";
import {FC} from "react";
import {NavLink, Outlet} from "react-router";
import {Box, Divider, Typography} from "@mui/material";
import Card from "../../lib/components/styled/Card.tsx";
import Logo from "../../layout/logo/Logo.tsx";

type OptionLinkProps = {
    name : string;
    to : string;
}
const OptionLink:FC<OptionLinkProps> = ({
    name, to
})=>{
    return (
        <Box sx={styles.option}>
            <NavLink to={to}>
                <Typography variant={'h6'}>
                    {name}
                </Typography>
            </NavLink>
        </Box>
    )
}
const AuthLayout:FC = () => {
    return (
        <Box sx={styles.page}>
            <Box sx={styles.column}>
                <Card>
                    <Box sx={styles.header}>
                        <Logo/>
                        <Box sx={styles.options}>
                            <OptionLink name={'Реєстрація'} to={'/signup'}/>
                            <OptionLink name={'Вхід'} to={'/login'}/>
                        </Box>
                    </Box>
                    <Divider/>
                    <Box sx={styles.content}>
                        <Outlet/>
                    </Box>
                </Card>

            </Box>
        </Box>
    )
}


export default AuthLayout;