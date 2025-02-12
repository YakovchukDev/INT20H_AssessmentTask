import {SxProps, Theme} from "@mui/material";

export const page:SxProps<Theme> = {
    display: "flex",
    flexDirection: "column",
    width : "100%",
    minHeight: "100vh",
    backgroundColor: 'background.default',
}
export const content:SxProps<Theme> = {
    display: "flex",
    flexDirection: "column",
    flexGrow: 1,
}