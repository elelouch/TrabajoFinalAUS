import apiClient from "../../../shared/api/apiClient";
import endpoints from "../../../shared/api/endpoints";
import type { AxiosRequestConfig } from "axios";

export interface SignUpCredentials {
    name: string;
    email: string;
    password: string;
}

export interface LoginCredentials {
    email: string;
    password: string;
}

export interface LoginResult {
    userId: string
    username: string
}

export const signUp = async (credentials: SignUpCredentials, config?: AxiosRequestConfig) => {
    const response = await apiClient.post(endpoints.auth.register, credentials, config);
    return response.data;
};

export const signIn = async (credentials: LoginCredentials, config?: AxiosRequestConfig): Promise<LoginResult> => {
    const response = await apiClient.post(endpoints.auth.login, credentials, config);
    return response.data as LoginResult;
};