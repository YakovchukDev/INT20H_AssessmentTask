import {FC} from "react";
import {Box} from "@mui/material";
import * as styles from "./profile.styles.ts";
import ProfileForm from "./component/profile-form/ProfileForm.tsx";
import {useSearchParams} from "react-router";
import CreatedList from "./component/created-list/CreatedList.tsx";
import CompletedList from "./component/completed-list/CompletedList.tsx";

const ProfilePage:FC = () => {
    const [params, setParams] = useSearchParams();
    const view = params.get("view");

    return (
        <Box sx={styles.container}>
            <Box sx={styles.content}>
                <ProfileForm/>
                <Box sx={{marginTop:'32px'}}>
                    {
                        view === "created" ? <CreatedList/>:
                        view === "completed" ? <CompletedList/> :
                        <></>
                    }
                </Box>

            </Box>

        </Box>
    )
}

export default ProfilePage;
