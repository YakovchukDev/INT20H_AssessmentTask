import {SxProps, Theme} from "@mui/material";

export const list:SxProps<Theme> = {
    marginTop : '20px',
    display: "flex",
    flexDirection: 'column',

    gap : '10px',
    width: "100%",
}
export const column:SxProps<Theme> = {
    display : 'flex',
    flexDirection : 'column',
    alignItems: 'center',
}