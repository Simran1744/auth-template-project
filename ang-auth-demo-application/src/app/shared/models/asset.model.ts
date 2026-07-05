

export enum AssetStatus{
    DRAFT = 'Draft',
    PENDINGREVIEW = 'PendingReview',
    ACTIVE = 'Active',
    REJECTED = 'Rejected',
    ARCHIVED = 'Archived'
}


export interface Asset {
    id: string;
    displayname: string;
    shortDescription: string;
    longDescription: string;
    price: number;
    currency: string;
    status: AssetStatus;
    version: string | null;
    isFeatured: boolean;
    totalDownloads: number;
    averageRating: number;
    reviewCount: number;
    createdAt: string;
    updatedAt: string;
    publishedAt: string | null;
}