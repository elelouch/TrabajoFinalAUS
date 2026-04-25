const BASE_URL = "/api";

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
        if (response.status === 401) {
            console.error("Unauthorized access - redirecting to login");
            // you could trigger redirect here
        }

        const errorBody = await response.text();
        throw new Error(errorBody || "Request failed");
    }

    // Try to parse JSON safely
    const contentType = response.headers.get("content-type");
    if (contentType && contentType.includes("application/json")) {
        return response.json();
    }

    return response.text() as unknown as T;
}

export default apiClient;