import {SxProps, Theme} from "@mui/material";

export const container:SxProps<Theme> = {
    width: '100%',
    height: '100%',
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
}
export const content:SxProps<Theme> = {
    marginTop : '128px',
    display : 'grid',
    width: '1440px',
    gridTemplateColumns : '400px 1fr',
    alignItems: 'flex-start',
    gap : '20px',
}