import {SxProps, Theme} from "@mui/material";

export const container:SxProps<Theme> = {
    padding : '20px',
}
export const list:SxProps<Theme> = {
    marginTop : '15px',
    display: 'grid',
    gridTemplateColumns: 'repeat(5, 1fr)',
    gap : '10px',
}