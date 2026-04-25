import apiClient from "#/shared/api/apiClient";
import type { LoginCredentials, LoginResult } from "#/features/auth/types/authTypes";

export async function signin(data: LoginCredentials): Promise<LoginResult> {
    return apiClient("/auth/signin", {
        method: "POST",
        body: JSON.stringify(data),
        auth: false,
    });
}

export async function getCurrentUser() {
    return apiClient("/auth/me", {
        method: "GET",
        auth: true,
    });
}

export async function logout() {
    return apiClient("/auth/logout", {
        method: "POST",
        auth: true,
    });
}