export type ApiErrorData = {
    message: string;
    code: string;
    details: unknown;
}

export class ApiError extends Error {
    data: ApiErrorData

    constructor(data: ApiErrorData) {
        super(data.message);
        this.data = data
    }
}
