import apiClient from "#/shared/api/apiClient";
import type { SignInCredentials, SignInResult, SignUpCredentials, SignUpResult } from "#/features/auth/types/authTypes";

export async function signin(data: SignInCredentials): Promise<SignInResult> {
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

export async function signup(data: SignUpCredentials): Promise<SignUpResult> {
    return apiClient("/auth/signup", {
        method: "POST",
        body: JSON.stringify(data),
        auth: false,
    });
}