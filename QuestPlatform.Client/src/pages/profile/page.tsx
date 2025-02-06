import {FC} from "react";
import {useParams} from "react-router";

const ProfilePage:FC = () => {
    const params = useParams();
    const id = Number(params.id);
    return (
        <div>
            Profile {id}
        </div>
    )
}

export default ProfilePage;