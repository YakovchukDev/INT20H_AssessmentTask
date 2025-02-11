import {SxProps, Theme} from "@mui/material";

export const page:SxProps<Theme> = {
    display : 'flex',
    flexDirection : 'column',
    width : '100%',
    minHeight : '100vh',
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor : 'background.default',
}
export const column:SxProps<Theme> = {
    display : 'flex',
    flexDirection : 'column',
    height : '100%',
    justifyContent : 'space-between',
    gap : '10px',
    width : '520px',

}
export const header:SxProps<Theme> = {
    display : 'flex',
    flexDirection : 'column',
    alignItems: 'center',
    gap : '15px',
}
export const options:SxProps<Theme> = {
    display : 'grid',
    gridTemplateColumns : 'repeat(2, 1fr)',
    width: '100%',
}
export const option:SxProps<Theme> = {
    'a' : {
        position : 'relative',
        alignItems: 'center',
        transition : '0.1s',
        padding : '12px',
        display:'flex',
        justifyContent:'center',
        textDecoration:'none',
        color : 'grey.400',
        '&:hover' : {
            color : 'grey.800'
        },
        ':before' : {
            content:'""',
            position:'absolute',
            left : '0',
            bottom: '0',
            transition : '0.1s',
            height:'3px',
            borderRadius:'5px',
            backgroundColor:'primary.main'
        }
    },
    '.active' : {
        color : 'grey.800',
        ':before': {
           width:'100%',
        },

    },

}
export const content:SxProps<Theme> = {
    marginTop : '32px',
}