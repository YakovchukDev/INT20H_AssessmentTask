import {SxProps, Theme} from "@mui/material";

export const container:SxProps<Theme> = {
    display : 'flex',
    flexDirection : 'column',
}
export const bottom:SxProps<Theme> = {
    marginTop : '32px',
}
export const submit:SxProps<Theme> = {
    padding: '10px',
}
export const inputColumn:SxProps<Theme> = {
    display : 'grid',
    gridTemplateColumns : 'repeat(2, 1fr)',
    gap : '16px',
}