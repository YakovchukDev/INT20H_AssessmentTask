import {FC} from "react";
import {Outlet} from "react-router";

const AuthLayout:FC = () => {
    return (
        <div>
           Auth
            <Outlet/>
        </div>
    )
}


export default AuthLayout;