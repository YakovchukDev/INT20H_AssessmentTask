import {SxProps, Theme} from "@mui/material";

export const zoomed:SxProps<Theme> = {
    '&:hover': {
        '.wallpaper' : {
            transform : 'translate(-50%, -50%) scale(1.05)',
        }
    }
}
export const container:SxProps<Theme> = {
    position: "relative",
    display : 'flex',
    backgroundColor : '#B0B0B0',
    width: '700px',
    height : '393px',
    overflow : 'hidden',

}
export const wallpaper:SxProps<Theme> = {
    position: "absolute",
    width : '100%',
    height : '100%',
    top : '50%',
    left : '50%',
    transform : 'translate(-50%, -50%)',
    zIndex : 1,
    backgroundImage : 'url(/wallpaper.png)',
    backgroundSize : 'cover',
    transition : '0.1s',

}
export const content:SxProps<Theme> = {
    display : 'flex',
    flexDirection : 'column',
    height : '100%',
    alignItems: 'flex-start',
    justifyContent : 'space-between',
    padding : '20px',
    zIndex : 5,
}