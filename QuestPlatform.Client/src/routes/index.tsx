import {createBrowserRouter} from "react-router";
import HomePage from "./home/page.tsx";
import AuthLayout from "./auth/layout.tsx";
import LoginPage from "./auth/pages/login/page.tsx";
import SignupPage from "./auth/pages/signup/page.tsx";
import EditorPage from "./editor/page.tsx";
import SettingsPage from "./editor/pages/setting/Settings.tsx";
import LevelPage from "./editor/pages/level/page.tsx";
import PreviewPage from "./editor/pages/preview/page.tsx";
import StaticsPage from "./editor/pages/stats/page.tsx";
import MainLayout from "../layout/main/Main.tsx";
import ProfilePage from "./profile/page.tsx";
import BrowsePage from "./browse/page.tsx";
import QuestPage from "./quest/page.tsx";
import GamePage from "./game/Game.tsx";

const Router = createBrowserRouter([
    {
        element : <AuthLayout/>,
        children : [
            {
                path : '/login',
                element : <LoginPage/>,
            },
            {
                path : '/signup',
                element : <SignupPage/>
            }
        ],
    },
    {
        path: '/game/:id',
        element : <GamePage/>
    },
    {
        path : '/',
        element : <MainLayout/>,
        children : [
            {
                index : true,
                element : <HomePage/>,
            },
            {
                path: '/profile',
                element: <ProfilePage/>,
            },
            {
                path: '/browse',
                element: <BrowsePage/>
            },
            {
                path : '/quest/:id',
                element: <QuestPage/>,
            },
            {
                path: '/editor/:questId',
                element: <EditorPage/>,
                children: [
                    {
                        index: true,
                        element: <SettingsPage/>,
                    },
                    {
                        path: 'view',
                        element: <PreviewPage/>,
                    },
                    {
                        path: 'stats',
                        element: <StaticsPage/>,
                    },
                    {
                        path: `level/:index`,
                        element: <LevelPage/>,
                    },
                ]
            },

        ]
    }
]);

export default Router;