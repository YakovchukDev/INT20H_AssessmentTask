import {SxProps, Theme} from "@mui/material";

export const page:SxProps<Theme> = {
    width: "100%",
    height : "100vh",
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    backgroundImage : "url(/game/wallpaper.jpg)"
}
export const container:SxProps<Theme> = {
    paddingTop : '128px',
    display : 'flex',
    flexDirection : 'column',
    height : '100%',

}