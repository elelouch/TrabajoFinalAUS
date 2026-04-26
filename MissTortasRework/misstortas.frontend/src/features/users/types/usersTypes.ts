export type User = {
    id: string;
    username: string;
    roles: string[];
};

export type UpdateUser = {
    username: string;
    email: string;
    enabled: boolean;
    roles: string[];
};

export type UserConsultancies = {
    id: number;
    // add other fields from backend
};