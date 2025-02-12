import {FC, ReactNode, useEffect, useState} from "react";
import {Button, Stack, SxProps, Theme} from "@mui/material";

const disabled:SxProps<Theme> = {
    backgroundColor: 'grey.500',
    boxShadow: 'none',
    '&:hover': {
        boxShadow: 'none',
    }
}

export type VariantType = string | {
    name : string;
    node : ReactNode;
}

const getVariantName = (variant : VariantType) => {
    if (typeof variant === "string") {
        return variant;
    }
    return variant.name;
}
const getVariantContent = (variant : VariantType) => {
    if (typeof variant === "string") {
        return variant;
    }
    return variant.node;
}

type SelectorProps = {
    name ?: string;
    value ?: string;
    variants : VariantType[];
    buttonSx ?: SxProps<Theme>;
    disabledButtonSx ?: SxProps<Theme>;
    onSelect ?: (name:string)=>void;
}

const Selector:FC<SelectorProps> = ({
    name, variants,
    value,
    buttonSx,
    disabledButtonSx,
    onSelect
})=>{

    const [currentVariant, setCurrentVariant] = useState<string>(value ?? getVariantName(variants[0]));
    const onItemClick = (variant:string)=>{
        if (onSelect) onSelect(variant);
        if (!value) {
            setCurrentVariant(variant);
        }
    }

    return (
        <>
            {
                name &&
                <input
                    name={name}
                    style={{display:'none'}}
                    value={currentVariant}
                    onChange={()=>{}}
                />
            }
            <Stack direction={'row'} gap={'10px'}>
                {
                    variants.map(variant=>{
                        const isCurrent = (value ?? currentVariant) === getVariantName(variant);
                        const onClick = ()=>{
                            onItemClick(getVariantName(variant));
                        }
                        const sx = !isCurrent ? (disabledButtonSx ?? disabled) : (buttonSx ?? {});
                        return (
                            <Button
                                variant={'contained'} key={getVariantName(variant)}
                                onClick={onClick} sx={sx}
                            >
                                {getVariantContent(variant)}
                            </Button>
                        )
                    })
                }
            </Stack>
        </>

    )
}

export default Selector;