export interface UserModel {
    id: number;
    name: string | null;
    email: string | null;
    password: string | null;
    bio: string | null;
    avatar: string | null;
    avatarImage?: File;
    totalBlogs?: number;
}
