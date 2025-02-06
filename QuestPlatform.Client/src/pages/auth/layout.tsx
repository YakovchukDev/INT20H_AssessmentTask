import {FC} from "react";
import {Outlet} from "react-router";
import styles from  "./auth.module.sass";

const AuthLayout:FC = () => {
    return (
        <div className={styles.container}>
            <Outlet/>
        </div>
    )
}


export default AuthLayout;