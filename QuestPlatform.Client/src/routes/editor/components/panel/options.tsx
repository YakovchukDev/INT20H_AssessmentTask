import VisibilityIcon from "@mui/icons-material/Visibility";
import SettingsIcon from "@mui/icons-material/Settings";
import BarChartIcon from "@mui/icons-material/BarChart";
import ShareIcon from "@mui/icons-material/Share";
import {VariantType} from "../../../../lib/components/styled/Selector.tsx";


const PanelOptions:VariantType[] = [
    {
        name : "view",
        node : <VisibilityIcon/>,
    },
    {
        name : "settings",
        node : <SettingsIcon/>,
    },
    {
        name : "stats",
        node : <BarChartIcon/>,
    },
    {
        name : "share",
        node : <ShareIcon/>,
    }
] ;
export default PanelOptions;