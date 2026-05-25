export interface UserProfile {
    id: string;
    username: string;
    email: string;
    bio: string | null;
    avatarUrl: string | null;
    createdAt: string;
}