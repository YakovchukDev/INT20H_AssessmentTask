import {SxProps, Theme} from "@mui/material";

export const page:SxProps<Theme> = {
    width: "100%",
    height: "100%",
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    backgroundColor: "background.default",
}
export const container:SxProps<Theme> = {
    margin: '128px',
    width: '1200px',
    display: 'grid',
    gap : '32px',
    gridTemplateColumns : '1fr auto',
}
export const content:SxProps<Theme> = {
    display: "flex",
    flexDirection: "column",
    // padding : '32px',
    // borderRadius : '16px',
}
export const panel:SxProps<Theme> = {
    display: "flex",
    flexDirection: "column",
}