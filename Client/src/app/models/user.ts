export interface User {
    id: number;
    userName: string;
    email: string;
    token: string;
    avatarUrl: string;
    dob: Date;
    gender: string;
    province: string;
    school: string;
    description: string;
    fullName: string,
    roles: string[];
    createdAt: Date;
    lastActive: Date;
}