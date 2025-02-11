import { Lock, LockOpen, TextFields } from "@mui/icons-material";
import { Box, Button, Stack, Typography } from "@mui/material";
import type { EditorOptions } from "@tiptap/core";
import { useCallback, useRef, useState } from "react";
import {
    LinkBubbleMenu,
    MenuButton,
    RichTextEditor,
    RichTextReadOnly,
    TableBubbleMenu,
    insertImages,
    type RichTextEditorRef,
} from "mui-tiptap";
import EditorMenuControls from "./EditorMenuControls.tsx";
import useExtensions from "./useExtensions";

const exampleContent = `
<h1>Mdoo</h1>
`

function fileListToImageFiles(fileList: FileList): File[] {

    return Array.from(fileList).filter((file) => {
        const mimeType = (file.type || "").toLowerCase();
        return mimeType.startsWith("image/");
    });
}

export default function Editor() {
    const extensions = useExtensions({
        placeholder: "Add your own content here...",
    });
    const rteRef = useRef<RichTextEditorRef>(null);
    const [isEditable, setIsEditable] = useState(true);
    const [showMenuBar, setShowMenuBar] = useState(true);

    const handleNewImageFiles = useCallback(
        (files: File[], insertPosition?: number): void => {
            if (!rteRef.current?.editor) {
                return;
            }
            const attributesForImageFiles = files.map((file) => ({
                src: URL.createObjectURL(file),
                alt: file.name,
            }));

            insertImages({
                images: attributesForImageFiles,
                editor: rteRef.current.editor,
                insertPosition,
            });
        },
        [],
    );

    // Allow for dropping images into the editor
    const handleDrop: NonNullable<EditorOptions["editorProps"]["handleDrop"]> =
        useCallback(
            (view, event, _slice, _moved) => {
                if (!(event instanceof DragEvent) || !event.dataTransfer) {
                    return false;
                }

                const imageFiles = fileListToImageFiles(event.dataTransfer.files);
                if (imageFiles.length > 0) {
                    const insertPosition = view.posAtCoords({
                        left: event.clientX,
                        top: event.clientY,
                    })?.pos;

                    handleNewImageFiles(imageFiles, insertPosition);
                    event.preventDefault();
                    return true;
                }
                return false;
            },
            [handleNewImageFiles],
        );

    const handlePaste: NonNullable<EditorOptions["editorProps"]["handlePaste"]> =
        useCallback(
            (_view, event, _slice) => {
                if (!event.clipboardData) {
                    return false;
                }

                const pastedImageFiles = fileListToImageFiles(
                    event.clipboardData.files,
                );
                if (pastedImageFiles.length > 0) {
                    handleNewImageFiles(pastedImageFiles);
                    return true;
                }

                // We return false here to allow the standard paste-handler to run.
                return false;
            },
            [handleNewImageFiles],
        );

    const [submittedContent, setSubmittedContent] = useState("");

    return (
        <>
            <Box
                sx={{
                    "& .ProseMirror": {
                        "& h1, & h2, & h3, & h4, & h5, & h6": {
                            scrollMarginTop: showMenuBar ? 50 : 0,
                        },
                    },
                }}
            >
                <RichTextEditor
                    ref={rteRef}
                    extensions={extensions}
                    content={exampleContent}
                    editable={isEditable}
                    editorProps={{
                        handleDrop: handleDrop,
                        handlePaste: handlePaste,
                    }}
                    renderControls={() => <EditorMenuControls />}
                    RichTextFieldProps={{
                        variant: "outlined",
                        MenuBarProps: {
                            hide: !showMenuBar,
                        },
                        footer: (
                            <Stack
                                direction="row"
                                spacing={2}
                                sx={{
                                    borderTopStyle: "solid",
                                    borderTopWidth: 1,
                                    borderTopColor: (theme) => theme.palette.divider,
                                    py: 1,
                                    px: 1.5,
                                }}
                            >
                                <MenuButton
                                    value="formatting"
                                    tooltipLabel={
                                        showMenuBar ? "Hide formatting" : "Show formatting"
                                    }
                                    size="small"
                                    onClick={() =>
                                        setShowMenuBar((currentState) => !currentState)
                                    }
                                    selected={showMenuBar}
                                    IconComponent={TextFields}
                                />

                                <MenuButton
                                    value="formatting"
                                    tooltipLabel={
                                        isEditable
                                            ? "Prevent edits (use read-only mode)"
                                            : "Allow edits"
                                    }
                                    size="small"
                                    onClick={() => setIsEditable((currentState) => !currentState)}
                                    selected={!isEditable}
                                    IconComponent={isEditable ? Lock : LockOpen}
                                />

                                <Button
                                    variant="contained"
                                    size="small"
                                    onClick={() => {
                                        setSubmittedContent(
                                            rteRef.current?.editor?.getHTML() ?? "",
                                        );
                                    }}
                                >
                                    Save
                                </Button>
                            </Stack>
                        ),
                    }}
                >
                    {() => (
                        <>
                            <LinkBubbleMenu />
                            <TableBubbleMenu />
                        </>
                    )}
                </RichTextEditor>
            </Box>
        </>
    );
}
