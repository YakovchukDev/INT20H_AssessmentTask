import {SxProps, Theme} from "@mui/material";

export const container:SxProps<Theme> = {
    width : '100%',
    height : '100%',
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    justifyContent: 'center',
    backgroundSize : 'cover',
    '&:hover' : {

    }
}
export const icon:SxProps<Theme> = {
    fontSize : '5em',
    color : 'primary.main',
    opacity : '0.5',
    cursor : 'pointer',
}