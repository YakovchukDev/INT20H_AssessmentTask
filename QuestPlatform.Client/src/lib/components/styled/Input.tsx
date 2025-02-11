import {Input, Select, styled, SxProps, Theme} from "@mui/material";

const style  = (theme):SxProps<Theme>=> {
    return  {
        '::after, ::before': {
            content: 'none',
        },
        padding: '10px 12px',
        borderRadius: '10px',
        border: 'solid 1px',
        borderColor: theme.palette.grey[300],
        fontFamily: theme.typography.fontFamily,
        'input': {
            padding: '3px',
            fontSize: '1em',
        }
    }
}

const TextInput = styled(Input)(({theme}) => {
    return style(theme);
});
export const SelectInput = styled(Select)(({theme})=>{
    return style(theme);
});

export default TextInput;