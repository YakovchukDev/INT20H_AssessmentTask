import {SxProps, Theme} from "@mui/material";

export const container:SxProps<Theme> = {
    display : 'flex',
    alignItems: 'center',
    justifyContent : 'space-between',
    width: '100%',
    padding : '5px 15px',
    backgroundColor : 'transparent',
    color : 'primary.main',
    border : 'solid 1px',
    borderColor : 'primary.main',
    'a' : {
        color: 'primary.main',
    },
    'a:hover' : {
        textDecoration: 'underline',
    },
    '.active' : {
    },

}
