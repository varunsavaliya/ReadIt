export class Blog {
  id?: number
  title!: string
  description!: string
  tags!: string
  createdBy?: number
  createdByName?: string
  categoryId?: number
  categoryName?: string
  createdOn?: Date
  file?: File
}
