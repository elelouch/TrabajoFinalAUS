import apiClient from "../../../shared/api/apiClient";

export interface SignUpCredentials {
  name: string;
  email: string;
  password: string;
}

export const SecurityEndpoints = {}

export const signUp = async (credentials: SignUpCredentials) => {
  const response = await apiClient.post("/auth/signup", credentials);
  return response.data;
};