import { ApiError, type ApiErrorData } from "#/shared/types/sharedTypes";

const BASE_URL = import.meta.env.VITE_API_ENDPOINT;

type FetchOptions = RequestInit & {
    auth?: boolean; // allow turning auth on/off
};

async function apiClient<T = any>(
    endpoint: string,
    options: FetchOptions = {}
): Promise<T> {
    const token = localStorage.getItem("authToken");

    const headers: HeadersInit = {
        "Content-Type": "application/json",
        ...(options.headers || {}),
    };

    // Request "interceptor"
    if (options.auth && token) {
        headers["Authorization"] = `Bearer ${token}`;
    }

    const response = await fetch(`${BASE_URL}${endpoint}`, {
        ...options,
        headers,
        credentials: "include",
    });

    // Response "interceptor"
    if (!response.ok) {
        const contentType = response.headers.get("content-type");

        if (contentType?.includes("application/json")) {
            const data = await response.json() as ApiErrorData;
            throw new ApiError(data);
        }
        const apierror: ApiErrorData = {
            message: "Request failed.",
            code: "",
            details:""
        }
        const text = await response.text();
        throw new ApiError(apierror);
    }

    // Try to parse JSON safely
    const contentType = response.headers.get("content-type");
    if (contentType && contentType.includes("application/json")) {
        return response.json();
    }

    return response.text() as unknown as T;
}

export default apiClient;