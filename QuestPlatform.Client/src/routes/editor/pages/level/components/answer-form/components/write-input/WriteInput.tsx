import {Box, Button, Checkbox, Collapse, FormControlLabel, IconButton, List, Stack} from "@mui/material";
import {createRef, FC, useState} from "react";
import * as styles from "./write.styles.ts";
import TextInput from "../../../../../../../../lib/components/styled/Input.tsx";
import DeleteIcon from '@mui/icons-material/Delete';
import { TransitionGroup } from 'react-transition-group';


export type VariantItemProps = {
    value : string;
    isCorrect : boolean;
    onChange ?: (value : string) => void;
    onRemove ?: () => void;
    onCorrect ?: (newValue:boolean)=>void;
}
const VariantItem:FC<VariantItemProps> = ({
    value, onChange,
    onRemove, isCorrect,
    onCorrect
})=>{
    const inputRef = createRef<HTMLInputElement>();

    const onTextChange = ()=>{
        if (!inputRef.current) return;
        if (onChange) {
            onChange(inputRef.current.value);
        }
    }
    const emitRemove = ()=>{
        onRemove?.();
    }
    const emitCorrection = ()=>{
        onCorrect?.(!isCorrect);
    }

    return (
        <Stack alignItems={'center'} gap={'10px'} direction={'row'} sx={styles.variant}>
            <TextInput
                onChange={onTextChange}
                inputRef={inputRef}
                sx={styles.variantInput}
                placeholder={"текст варіанту"}
                value={value}
            />
            <Stack sx={{marginLeft:'10px'}} direction={'row'} gap={'10px'}>
                <FormControlLabel
                    onChange={emitCorrection}
                    name={"task_type"}
                    control={<Checkbox checked={isCorrect} />}
                    label="Правильна відповідь"
                />
                <IconButton onClick={emitRemove}>
                    <DeleteIcon color={'primary'}/>
                </IconButton>

            </Stack>

        </Stack>
    )
}

type VariantType = {
    id : number;
    value : string;
    correct : boolean;
}
export type WriteInputProps = {};
const WriteInput:FC<WriteInputProps> = ()=>{
    const [id, setId] = useState(0);
    const [variants, setVariants] = useState<VariantType[]>([]);


    const addNewVariant = ()=>{
        const newVariants = variants.map(variant=>{
            return {...variant};
        });
        newVariants.push({
            id : id,
            value : "",
            correct : false,
        });
        setVariants(newVariants);
        setId((prev)=>prev+1);
    }
    const changeVariantText = (id:number, text:string)=>{
        const newVariants = variants.map(variant=>{
            return {...variant};
        });
        const newVariant = newVariants.find(v=>{
            return v.id === id;
        });
        if (newVariant === undefined){
            return;
        }
        newVariant.value = text;
        setVariants(newVariants);
    }
    const changeVariantCorrection = (id:number, value:boolean)=>{
        const newVariants = variants.map(variant=>{
            return {...variant};
        });
        const variant = newVariants.find(v=>{
            return v.id === id;
        });
        if (variant === undefined){
            return;
        }
        console.log(value);
        variant.correct = value;
        setVariants(newVariants);
    }

    const onRemove = (id:number)=>{
        const newValues = variants.filter(v=>{
            return v.id !== id;
        });
        setVariants(newValues);
    }

    const variantsText = JSON.stringify(variants);

    return (
        <Box sx={styles.container}>
            <input name={"answer_variants"} value={variantsText} style={{display:"none"}} onChange={()=>{}}/>
            <List>
                <TransitionGroup>
                    {
                        variants.map((variant)=>{
                            return (
                                <Collapse key={variant.id}>
                                    <VariantItem
                                        isCorrect={variant.correct}
                                        onChange={(text)=>changeVariantText(variant.id, text)}
                                        value={variant.value}
                                        onCorrect={(newValue)=> changeVariantCorrection(variant.id, newValue)}
                                        onRemove={()=>onRemove(variant.id)}
                                    />
                                </Collapse>

                            )
                        })
                    }
                </TransitionGroup>

            </List>
            <Button sx={{marginTop:'20px', padding : '10px'}} onClick={addNewVariant}>
                Додати новий варіант
            </Button>
            <Stack sx={{marginTop:'20px'}}>
                <FormControlLabel
                    name={"task_type"}
                    control={<Checkbox defaultChecked />}
                    label="Вибір з Декількох"
                />
            </Stack>
        </Box>
    )
}

export default WriteInput;