import {createRef, FC, useState} from "react";
import FormCard from "../form-card/FormCard.tsx";
import {Box, Button, IconButton, Stack, Typography} from "@mui/material";
import CloseIcon from '@mui/icons-material/Close';
import * as styles from "./tag.styles.ts";
import TagRoundedIcon from '@mui/icons-material/TagRounded';
import TextInput from "../../../../../../lib/components/styled/Input.tsx";

type TagProps = {
    tag : string;
    onRemove : (tag:string)=>void;
}
const Tag:FC<TagProps> = ({
    tag, onRemove
})=>{
    return (
        <Box sx={styles.tagContainer} key={tag}>
            <Typography variant={'body2'} sx={styles.text}>
                #{tag}
            </Typography>
            <IconButton onClick={()=>{onRemove(tag)}} sx={styles.button}>
                <CloseIcon sx={styles.close}/>
            </IconButton>
        </Box>
    )
}

type TagInputProps = {
    onAdd : (tag:string) => string|undefined;
}
const TagInput:FC<TagInputProps> = ({
    onAdd
})=>{
    const inputRef = createRef<HTMLInputElement>();
    const [errorText, setErrorText] = useState<string>();

    const onClick = ()=>{
        if (!inputRef.current) return;
        const msg = onAdd(inputRef.current.value);
        inputRef.current.value = '';
        setErrorText(msg);
    }
    return (
        <Box sx={styles.inputContainer}>
            <Stack direction={'row'} gap={'5px'}>
                <TextInput inputRef={inputRef} sx={styles.input} placeholder={'tag'}/>
                <Button onClick={onClick} sx={styles.add}>Add</Button>
            </Stack>
            {
                errorText &&
                <Typography variant={'body2'} color={'error'}>{errorText}</Typography>
            }
        </Box>
    )
}

const TagsInput:FC = ()=>{
    const [tags, setTags] = useState<string[]>([
        "game"
    ]);

    const removeTag = (tag:string)=>{
        const newTags= tags.filter(t=>{
            return  tag !== t;
        });
        setTags(newTags);
    }
    const onAddTag = (tag:string)=>{
        if (tags.includes(tag)){
            return 'tag already in array';
        }
        if (tag.length === 0){
            return 'tag is null';
        }
        setTags([...tags, tag]);
        return undefined
    }

    return (
        <FormCard
            title={"Теги"}
            subtitle={"Вибрати категорію гри. Якої теми буде стосуватися гра. Це допоможе іншим гравцям знайти ваш квест"}
            icon={TagRoundedIcon}
        >
            <Stack gap={'10px'}>
                <Stack direction={'row'} gap={'5px'}>
                    {
                        tags.map(tag=>{
                            return (
                                <Tag
                                    onRemove={removeTag}

                                    key={tag}
                                    tag={tag}
                                />
                            )
                        })
                    }
                </Stack>
                <TagInput onAdd={onAddTag}/>
            </Stack>


        </FormCard>
    )
}

export default TagsInput;