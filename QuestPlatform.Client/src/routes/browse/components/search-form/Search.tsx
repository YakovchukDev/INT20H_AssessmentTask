import {FC, ReactNode, useState} from "react";
import Card from "../../../../lib/components/styled/Card.tsx";
import {Button, Fade, Rating, Stack, Typography} from "@mui/material";
import TextInput from "../../../../lib/components/styled/Input.tsx";
import TuneIcon from '@mui/icons-material/Tune';
import CategorySelector from "../../../../layout/category-selector/CategorySelector.tsx";
import PsychologyIcon from "@mui/icons-material/Psychology";
import SearchIcon from '@mui/icons-material/Search';
import MinusIcon from '@mui/icons-material/Remove';
import CategoryIcon from '@mui/icons-material/Category';
import TimeIcon from '@mui/icons-material/AccessTimeFilled';
import PeopleAltIcon from '@mui/icons-material/PeopleAlt';

type ParamItemProps = {
    name : string;
    children: ReactNode;
    icon ?: ReactNode;
}
const ParamItem:FC<ParamItemProps> = ({
    name, children, icon
})=>{
    return (
        <Stack gap={'5px'} alignItems={'flex-start'} justifyContent={'space-between'}>
            <Typography display={'flex'} gap={'10px'}>
                {icon}
                <Typography variant={'subtitle1'}>{name}</Typography>
            </Typography>
            {children}
        </Stack>
    )
}

const SearchForm:FC = ()=>{
    const [paramsInfoHidden, setParamsHidden] = useState<boolean>(true);

    return (
        <Card sx={{padding:'20px'}}>
            <Typography variant={'h6'}>Пошук</Typography>
            <Stack marginTop={'20px'} direction={'row'} alignItems={'center'} gap={'20px'}>
                <TextInput
                    sx={{flexGrow:'1'}}
                    placeholder={'Ключове слово'}
                />
            </Stack>
            <Stack marginTop={'20px'} gap={'15px'}>
                <Typography
                    onClick={()=>setParamsHidden((prev)=>!prev)}
                    sx={{cursor:'pointer'}} display={'flex'} alignItems={'center'} gap={'10px'} variant={'subtitle1'} color={'info'}>
                    <TuneIcon/>
                    <Typography variant={'subtitle2'}>
                        Додаткові Параметри
                    </Typography>
                </Typography>
                <Fade in={!paramsInfoHidden}>
                    <Stack display={!paramsInfoHidden ? 'flex' : 'none'} gap={'20px'}>
                        <ParamItem icon={<CategoryIcon/>} name={"Категорія"}>
                            <CategorySelector name={"categories"}/>
                        </ParamItem>
                        <ParamItem name={"Складність"}>
                            <Rating
                                name={'difficulty'}
                                icon={<PsychologyIcon color={'primary'} sx={{fontSize:'32px'}}/>}
                                emptyIcon={<PsychologyIcon sx={{fontSize:'32px'}}/>}
                            />
                        </ParamItem>
                        <ParamItem icon={<TimeIcon/>} name={"Час"}>
                            <Stack direction={'row'} alignItems={'center'} gap={'5px'}>
                                <TextInput inputProps={{min:"0"}} type={'number'}/>
                                <MinusIcon/>
                                <TextInput inputProps={{min:"0"}} type={'number'}/>
                            </Stack>
                        </ParamItem>
                        <ParamItem icon={<PeopleAltIcon/>} name={"Команди"}>
                            <Stack direction={'row'} alignItems={'center'} gap={'5px'}>
                                <TextInput inputProps={{min:"0"}} type={'number'}/>
                                <MinusIcon/>
                                <TextInput inputProps={{min:"0"}} type={'number'}/>
                            </Stack>
                        </ParamItem>

                    </Stack>
                </Fade>
            </Stack>
            <Button padding={'5px'} sx={{marginTop:'20px'}}>
                <Stack direction={'row'} gap={'10px'}>
                    <SearchIcon/> Пошук
                </Stack>
            </Button>
        </Card>
    )
}

export default SearchForm;