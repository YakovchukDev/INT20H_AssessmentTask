import {FC} from "react";
import './styles/index.sass';
import {Route, Routes} from 'react-router';
import HomePage from './pages/home/page.tsx';
import AuthLayout from './pages/auth/layout.tsx';
import LoginPage from "./pages/auth/login/page.tsx";
import SignupPage from "./pages/auth/signup/page.tsx";
import ProfilePage from "./pages/profile/page.tsx";
import QuestPage from "./pages/quest/page.tsx";
import NotFoundPage from "./pages/not-found/page.tsx";

const App:FC = ()=>{
    return (
       <Routes>
           <Route
               index
               element={<HomePage/>}
           />
           <Route
               element={<AuthLayout/>}
           >
               <Route
                   path={"/login"}
                   element={<LoginPage/>}
               />
               <Route
                   path={"/signup"}
                   element={<SignupPage/>}
               />
           </Route>
           <Route
               path={"/profile/:id"}
               element={<ProfilePage/>}
           />
           <Route
               path={"/quest/:id"}
               element={<QuestPage/>}
           />
           <Route path={"*"} element={
               <NotFoundPage/>
           }/>
       </Routes>
    )
}

export default App;