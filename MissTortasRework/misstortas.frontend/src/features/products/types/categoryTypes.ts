export interface UpdateCategory {
    viewerSubjectIds?: string[];
    parentId?: string;
    isFinal?: boolean;
    name?: string;
}

export interface CreateCategory {
    viewerSubjectIds?: string[];
    parentId?: string;
    isFinal: boolean;
    name: string;
}

export interface Category {
    id: string;
    name: string;
    parentId?: string;
    isFinal: boolean;
    children?: Category[];
}