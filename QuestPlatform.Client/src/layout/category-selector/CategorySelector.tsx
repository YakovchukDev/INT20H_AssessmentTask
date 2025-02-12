import {FC} from "react";
import * as styles from "./selector.styles.ts";
import {MenuItem, Select} from "@mui/material";

const Categories = [
    "Ігри",
    "Аніме",
    "Фільми",
    "Манги",
    "Спорт",
]
export type CategorySelectorProps = {
    name : string;
}
const CategorySelector:FC<CategorySelectorProps> = ({
    name
})=>{
    return (
        <Select onChange={()=>{}} name={name} sx={styles.select}>
            {
                Categories.map(category=>{
                    return (
                        <MenuItem value={category} key={category}>
                            {category}
                        </MenuItem>
                    )
                })
            }
        </Select>
    )
}

export default CategorySelector;