import {SxProps, Theme} from "@mui/material";

export const container:SxProps<Theme> = {
    display : 'flex',
    flexDirection : 'column',
    padding : '20px',
}
export const links:SxProps<Theme> = {
    display : 'flex',
    gridTemplateColumns : 'repeat(4, 1fr)',
    gap : '10px'
}
