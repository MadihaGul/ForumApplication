
export type PostDetail = {
    id : number;
    title : string;
    detail : string;
    createdTime: Date;
    updatedTime: Date;
    comments:string[]; 
    numberOfComment: number;
};