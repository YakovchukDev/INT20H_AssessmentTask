import {User} from "./user.ts";

export type LevelType = {
    id: number;
    pageNumber: number;
    title: string;
}

export type QuestType = {
    id : number;
    title : string;
    description : string;
    authorId : number;
    author : User;
    rating : number;
}
