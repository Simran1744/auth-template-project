export enum SellerStatus{
    PENDING = 'Pending',
    APPROVED = 'Approved',
    REJECTED = 'Rejected',
    SUSPENDED = 'Suspended'
}


export interface SellerProfile {
    id: string;
    displayname: string;
    bio: string | null;
    avatarUrl: string | null;
    nexusModsProfileUrl: string | null;
    gitHubProfileUrl: string | null;
    websiteUrl: string | null;
    status: SellerStatus
    isFeatured: boolean | null;
    totalSales: number | null;
    createdAt: string;
}