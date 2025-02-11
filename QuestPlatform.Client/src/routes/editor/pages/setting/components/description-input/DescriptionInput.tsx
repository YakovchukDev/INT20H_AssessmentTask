import {FC, useState} from "react";
import FormCard from "../form-card/FormCard.tsx";
import DescriptionIcon from '@mui/icons-material/Description';
import "react-quill/dist/quill.snow.css";
import TiptapEditor from "../../../../../../layout/editor/editor.tsx";
import { Stack } from "@mui/material";

const DescriptionInput:FC = ()=>{
    const [content, setContent] = useState("");

    return (
        <FormCard alwaysExpand icon={DescriptionIcon} title={'Опис'}>
            <Stack>
                <input name={'description'}
                       onChange={()=>{}}
                       style={{display:'none'}}
                       value={content}
                />
                <TiptapEditor/>
            </Stack>

        </FormCard>
    )
}

export default DescriptionInput;