import {SxProps, Theme} from "@mui/material";

export const item:SxProps<Theme> = {
    display: "flex",
    alignItems: "center",
    gap : "10px",
    padding: "5px 10px",
    borderRadius : "10px",
    backgroundColor : "grey.50",
    width: "360px",
    transition : "0.09s",
    cursor: 'pointer',
    boxShadow : "1",
    '&:hover': {
        backgroundColor: "grey.100",
        boxShadow: "6",
    }
}
export const selected:SxProps<Theme> = {
    "&:hover": {
    }
}