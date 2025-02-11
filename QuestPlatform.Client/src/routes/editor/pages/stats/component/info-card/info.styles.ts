import {SxProps, Theme} from "@mui/material";

export const container:SxProps<Theme> = {
    display: "flex",
    flexDirection: "column",
    padding : '15px',
    borderRadius: '10px',
    backgroundColor : 'grey.200',
}
export const content:SxProps<Theme> = {
    display: "flex",
    marginTop : '20px'
}