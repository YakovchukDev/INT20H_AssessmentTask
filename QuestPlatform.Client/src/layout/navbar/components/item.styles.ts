import {SxProps, Theme} from "@mui/material";

export const container:SxProps<Theme> = {
    display : 'flex',
    alignItems: 'center',
    padding : '15px 20px',
    '&:hover' : {
        'div' : {
            '::after': {
                width : '100%'
            }
        }
    },

}
export const content:SxProps<Theme> = {
    display : 'flex',
    flexDirection : 'column',
    width: '100%',
    '::after': {
        alignSelf: 'center',
        content: '""',
        width: '0',
        height: '2px',
        backgroundColor: 'primary.main',
        transition : '0.2s',
    }
}
export const name:SxProps<Theme> = {
    color : 'primary.main',
    lineHeight: '1.3em',
    transition : '0.1s',
}
