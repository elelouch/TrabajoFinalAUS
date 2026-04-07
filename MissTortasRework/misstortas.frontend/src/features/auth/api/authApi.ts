// Lightweight auth API client using fetch
// Exports functions: login, register, logout, refreshToken, getProfile
// Does not enforce storage strategy; helper functions for localStorage are provided.

import apiClient from "../../../shared/api/apiClient";

// Types
export interface LoginPayload {
  email: string;
  password: string;
}

export interface RegisterPayload {
  name: string;
  email: string;
  password: string;
}

export interface AuthResponse {
  accessToken: string;
  refreshToken?: string;
  expiresIn?: number;
  user?: UserProfile;
}

export interface UserProfile {
  id: string;
  name: string;
  email: string;
}

export const AUTH_TOKEN_KEY = "auth:accessToken";
export const AUTH_REFRESH_KEY = "auth:refreshToken";

export function setAccessToken(token: string | null) {
  if (token) localStorage.setItem(AUTH_TOKEN_KEY, token);
  else localStorage.removeItem(AUTH_TOKEN_KEY);
}

export function getAccessToken(): string | null {
  return localStorage.getItem(AUTH_TOKEN_KEY);
}

export function setRefreshToken(token: string | null) {
  if (token) localStorage.setItem(AUTH_REFRESH_KEY, token);
  else localStorage.removeItem(AUTH_REFRESH_KEY);
}

export function getRefreshToken(): string | null {
  return localStorage.getItem(AUTH_REFRESH_KEY);
}

/** Authenticate and return tokens + user info */
export const login = async (payload: LoginPayload): Promise<AuthResponse> => {
  const response = await apiClient.post<AuthResponse>("/auth/login", payload);
  return response.data;
};

/** Register a new user */
export const register = async (payload: RegisterPayload): Promise<AuthResponse> => {
  const response = await apiClient.post<AuthResponse>("/auth/register", payload);
  return response.data;
};

/** Logout (server-side) and clear local tokens */
export const logout = async (): Promise<void> => {
  await apiClient.post("/auth/logout");
};

/** Exchange refresh token for a new access token */
export const refreshToken = async (): Promise<AuthResponse> => {
  const response = await apiClient.post<AuthResponse>("/auth/refresh");
  return response.data;
};

/** Get current authenticated user's profile */
export const getProfile = async (): Promise<UserProfile> => {
  const response = await apiClient.get<UserProfile>("/auth/profile");
  return response.data;
};