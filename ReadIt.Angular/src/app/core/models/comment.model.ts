import { UserModel } from "./user.model"

export interface CommentModel {
    id: number
    text: string
    blogId: number
    createdBy: number | null
    user?: UserModel | null
    name?:string | null
    email?:string | null
    website?: string | null
    createdOn: Date
}
