import {createRef, FC, useEffect, useState} from "react";
import {Box, SxProps, Theme} from "@mui/material";
import * as styles from "./uploader.styles.ts";
import AddPhotoAlternateIcon from '@mui/icons-material/AddPhotoAlternate';

export type UploaderProps = {
    sx ?: SxProps<Theme>;
}
const Uploader:FC<UploaderProps> = ({sx})=>{
    const [file, setFile] = useState<File>();
    const imgInput = createRef<HTMLInputElement>();
    const imgRef = createRef<HTMLDivElement>();

    useEffect(()=>{
        if (!file || !imgRef) return;
        const reader = new FileReader();
        reader.onload = (ev)=>{
            if (!imgRef.current)return;
            imgRef.current.style.backgroundImage = `url(${ev.target?.result})`;
        }
        reader.readAsDataURL(file);
    }, [file]);

    const onClick = (ev:any)=>{
        if (imgInput.current) imgInput.current.click();

    }
    const onChange = (ev)=>{
        if (!imgInput.current || !imgInput.current.files) return;
        const file = imgInput.current.files[0];
        setFile(file);
    }

    const renderIcon = Boolean(file);

    return (
        <Box ref={imgRef} sx={styles.container}>
            <input
                ref={imgInput}
                style={{display:"none"}}
                type={'file'}
                onChange={onChange}
            />
            {
                !renderIcon &&
                <AddPhotoAlternateIcon onClick={onClick}  sx={styles.icon}/>
            }
        </Box>
    )
}

export default Uploader;