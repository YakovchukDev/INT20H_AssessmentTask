import {SxProps, Theme} from "@mui/material";

export const select:SxProps<Theme> = {
    display : 'flex',
    width : '320px',
    outline : 'none',
    backgroundColor : 'transparent',
    boxShadow : '0 0 1px 1px rgba(0, 0, 0, 0.12)',
    '.MuiSelect-select' : {
        padding : '12px',
    },
    'fieldset' : {
        display : 'none',
    }
}