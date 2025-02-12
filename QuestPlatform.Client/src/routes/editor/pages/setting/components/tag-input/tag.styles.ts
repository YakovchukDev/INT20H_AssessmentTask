import {SxProps, Theme} from "@mui/material";

export const tagContainer:SxProps<Theme> = {
    padding : '3px 7px',
    borderRadius : '4px',
    backgroundColor : 'grey.300',
    boxShadow : '0 0 1px 1px rgba(0, 0, 0, 0.12)',
    display: 'flex',
    gap : '6px',
    alignItems: 'center',
}
export const text:SxProps<Theme> = {
    color : 'grey.900',
}
export const button:SxProps<Theme> = {
    padding : '3px',
}
export const close:SxProps<Theme> = {
    fontSize : '0.7em',
    color : 'danger.main'
}
export const inputContainer:SxProps<Theme> = {
    display: 'flex',
    flexDirection: 'column',
    gap : '5px',
}
export const input:SxProps<Theme> = {
    padding : '5px',
    fontSize : '0.9em',
}
export const add:SxProps<Theme> = {

}