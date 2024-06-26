import { CommentModel } from "./comment.model"
import { UserModel } from "./user.model"

export class Blog {
  id!: number
  title!: string
  description!: string
  tags!: string
  createdBy!: number
  categoryId!: number
  user!: UserModel
  totalComments?: number
  categoryName?: string
  createdOn?: Date
  blogImage?: File | null
  blogImageUrl?: string
}
