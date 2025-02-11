import MuiCard from "@mui/material/Card";
import {styled} from "@mui/material";

const Card = styled(MuiCard)(({theme})=>{
    return {
        display : 'flex',
        flexDirection : 'column',
        padding : '32px',
        borderRadius : '16px',
        backgroundColor : theme.palette.background.paper,
        boxShadow : 'none',
    }
});
export default Card;