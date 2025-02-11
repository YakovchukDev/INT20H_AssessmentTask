import {SxProps, Theme} from "@mui/material";

export const container:SxProps<Theme> = {
    display: 'flex',
    flexDirection : 'column',
    alignItems: 'center',
    width: '100%',
    backgroundColor : 'white',
}
export const content:SxProps<Theme> = {
    display: 'flex',
    justifyContent: 'space-between',
}
export const left:SxProps<Theme> = {
    display: 'flex',
    alignItems: 'center',
}
export const right:SxProps<Theme> = {
    display: 'flex',
    alignItems: 'center',
}