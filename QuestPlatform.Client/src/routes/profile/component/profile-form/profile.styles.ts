import {SxProps, Theme} from "@mui/material";

export const container:SxProps<Theme> = {
}
export const avatar:SxProps<Theme> = {
    width: "64px",
    height: "64px",
    backgroundColor : "primary.main",
    fontSize: "2em",
}
export const option:SxProps<Theme> = {
    position: "relative",
    display: "flex",
    alignItems: "center",
    padding : '10px',
    gap : '10px',
    color : 'primary.main',
    '::after': {
        content: '""',
        position: 'absolute',
        bottom: 0,
        left: '50%',
        transform: 'translateX(-50%)',
        width: '0',
        height: '3px',
        backgroundColor: 'primary.main',
        transition : '0.15s',
        alignSelf: 'center',
        borderRadius : '3px',
    },
    '.active' : {
        width: '80%',

    }
}
export const active:SxProps<Theme> = {
    '::after': {
        width : "90%",
    }
}
export const circle:SxProps<Theme> = {
    display: "flex",
    alignItems : "center",
    justifyContent: "center",
    backgroundColor: "primary.main",
    color : 'white',
    width: '28px',
    height: '28px',
    borderRadius: '100%',

}