import {
    Accordion,
    AccordionDetails,
    AccordionSummary,
    Box,
    CardProps,
    Stack,
    SxProps,
    Theme,
    Typography
} from "@mui/material";
import {ElementType, FC, ReactNode, useState} from "react";
import * as styles from "./card.styles.ts";
import {ExpandMore} from "@mui/icons-material";


export type FormCardProps = CardProps & {
    title ?: string;
    subtitle ?: string;
    icon ?: ElementType<{sx:SxProps<Theme>}>;
    children?: ReactNode;
    alwaysExpand ?: boolean;
}
const FormCard:FC<FormCardProps> = ({
    title, subtitle, icon,
    children, alwaysExpand,
})=>{
    const [expanded, setExpand] = useState<boolean>(alwaysExpand ?? false);
    const Icon = icon;

    const onExpand = ()=>{
        setExpand((prev)=>!prev);
    }
    const expandIcon = !alwaysExpand ? <ExpandMore onClick={onExpand}/> : undefined;

    return (
        <Accordion expanded={expanded} sx={styles.container}>
            <AccordionSummary onClick={!alwaysExpand ? onExpand : undefined} expandIcon={expandIcon}>
                    <Stack alignItems={'center'} direction={'row'} gap={'10px'}>
                        {Icon &&
                            <Icon sx={styles.icon}/>
                        }
                        {title &&
                            <Typography fontWeight={'bold'} variant={'h6'}>
                                {title}
                            </Typography>
                        }
                    </Stack>
            </AccordionSummary>
            <AccordionDetails>
                <Stack gap={'10px'}>
                    {
                        subtitle &&
                        <Typography variant={'subtitle2'}>
                            {subtitle}
                        </Typography>
                    }
                    <Box sx={styles.content}>
                        {children}
                    </Box>
                </Stack>

            </AccordionDetails>
        </Accordion>

    )
}

export default FormCard;