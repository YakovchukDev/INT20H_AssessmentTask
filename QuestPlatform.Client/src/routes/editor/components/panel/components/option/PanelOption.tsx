import {ElementType, FC} from "react";
import {Box, Button} from "@mui/material";

export type OptionType = {
    icon : ElementType;
    name : string;
}
export type OptionProps = {
    option : OptionType;
}
const PanelOption:FC<OptionProps> = ({option})=>{
    const Icon = option.icon;
    return (
        <Box>
            <Button>
                <Icon/>
            </Button>
        </Box>
    )
}

export default PanelOption;