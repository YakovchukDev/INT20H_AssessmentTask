import {createTheme} from "@mui/material";

const theme = createTheme({
    palette : {
        primary : {
            main : '#000',
            contrastText : '#fff',
        },
        background : {
            default : '#e9e9e9',
            paper : '#fff',
        },
        info : {
            main : '#3078b6',
        },
        warning  : {
            main : '#FF2929',
        }
    },
    typography : {
        fontFamily : `"IBM Plex Mono", serif`,

        body1 : {
            fontFamily : `Inter, sans-serif`,
        },
        body2 : {
            fontFamily : `Inter, sans-serif`,
        },

    },
    components : {
        MuiButton : {
            defaultProps : {
                variant : 'contained',
            },
        }
    }
});

export default theme;