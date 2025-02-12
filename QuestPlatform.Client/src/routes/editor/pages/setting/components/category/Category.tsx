import {FC} from "react";
import FormCard from "../form-card/FormCard.tsx";
import CategoryIcon from '@mui/icons-material/Category';

import CategorySelector from "../../../../../../layout/category-selector/CategorySelector.tsx";



const CategoryInput:FC = ()=>{
    return (
        <FormCard
            title={'Категорія'}
            subtitle={'Вибрати категорію гри. Якої теми буде стосуватися гра. Це допоможе іншим гравцям знайти ваш квест'}
            icon={CategoryIcon}
        >
            <CategorySelector name={"categories"}/>
        </FormCard>
    )
}

export default CategoryInput;