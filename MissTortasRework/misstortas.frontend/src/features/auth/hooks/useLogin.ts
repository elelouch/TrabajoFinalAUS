import { useCallback, useState } from "react";
import type { LoginCredentials, LoginResult } from "@/features/auth/services/authService";

type UseLoginReturn = {
  credentials: LoginCredentials;
  setCredentials: (c: Partial<LoginCredentials>) => void;
  handleChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  login: () => Promise<LoginResult | null>;
  logout: () => void;
  loading: boolean;
  error: string | null;
  isAuthenticated: boolean;
};

export default function useLogin(
  initial: LoginCredentials = { email: "", password: "" }
): UseLoginReturn {
  const [credentials, setCredentialsState] = useState<LoginCredentials>(initial);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  // Using cookie-based auth (server sets cookie). Client should not store or rely on access tokens.
  const isAuthenticated = false;

  const setCredentials = useCallback((c: Partial<LoginCredentials>) => {
    setCredentialsState((prev) => ({ ...prev, ...c }));
  }, []);

  const handleChange = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setCredentials({ [name]: value } as Partial<LoginCredentials>);
  }, [setCredentials]);

    const login = useCallback(async (): Promise<LoginResult | null> => {
        setLoading(true);
        setError(null);

        try {
            const result = await signIn(credentials);
            // Server handles authentication via cookies (Set-Cookie). No client-side token storage.
            setLoading(false);

            // Display success message for 204 response
            setError("Login successful");
            return result;
        } catch (err: unknown) {
            console.log(err);
            const extractMessage = (error: unknown): string | undefined => {
                if (typeof error === "string") return error;
                if (error instanceof Error) return error.message;
                const maybe = error as Record<string, unknown> | undefined;
                const response = maybe?.response as Record<string, unknown> | undefined;
                const data = response?.data as Record<string, unknown> | undefined;
                const msg = data?.message as string | undefined || data?.Message as string | undefined;
                return msg;
            };
            const serverMessage = extractMessage(err);
            setError(serverMessage || "Login failed");
            setLoading(false);
            return null;
        }
    }, [credentials]);

  const logout = useCallback(() => {
    // no-op client side; server should clear auth cookie via endpoint
  }, []);

  return {
    credentials,
    setCredentials,
    handleChange,
    login,
    logout,
    loading,
    error,
    isAuthenticated,

  };
}
