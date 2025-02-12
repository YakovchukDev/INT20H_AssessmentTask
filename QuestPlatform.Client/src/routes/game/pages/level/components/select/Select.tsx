import {FC, useState} from "react";
import {Box, Checkbox, Stack, Typography} from "@mui/material";
import * as styles from "./select.styles.ts";

export type SelectItemProps = {
    checked : boolean;
    value : string;
    onChecked : (newValue:boolean)=>void;
}
const SelectItem:FC<SelectItemProps> = ({
   checked, value, onChecked,
})=>{

    return (
        <Box
            onClick={()=>{onChecked(!value)}}
            sx={[styles.item, checked ? styles.selected : undefined]}
        >
            <Checkbox
                checked={checked}
            />
            <Typography>
                {value}
            </Typography>
        </Box>
    )
}
export type SelectProps = {
    values : string[];
    name : string;
    onlyOneCorrect: boolean;
}
const Select:FC<SelectProps> = ({
    values, onlyOneCorrect
})=>{
    const [checked, setChecked] = useState<boolean[]>(values.map(()=>false));
    const onChecked = (index:number)=>{
        const newChecked = [...checked];
        if (onlyOneCorrect){
            newChecked.fill(false);
        }
        newChecked[index] = !newChecked[index];
        setChecked(newChecked);
    }

    return (
        <Stack alignItems={'flex-start'} gap={'15px'}>
            {
                values.map((value, index)=>{
                    return (
                        <SelectItem
                            checked={checked[index]}
                            value={value}
                            onChecked={()=>{onChecked(index)}}
                        />
                    )
                })
            }
        </Stack>
    )
}

export default Select;