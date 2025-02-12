import {FC} from "react";
import {GlobalStyles, ThemeProvider} from '@mui/material';
import theme from './theme/theme.ts';
import {RouterProvider} from "react-router";
import Router from "./routes";
import './styles/index.css';

const App:FC = ()=>{
    return (
        <ThemeProvider theme={theme}>
            <GlobalStyles styles={{
                "*, ::after, ::before" : {
                    padding : 0,
                    margin : 0,
                    boxSizing : 'border-box',
                },
                'a' : {
                    textDecoration : 'none',
                }
            }}/>
            <RouterProvider router={Router}/>
        </ThemeProvider>
    )
}

export default App;