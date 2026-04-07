import { useCallback, useEffect, useState } from "react";

type Credentials = {
  email: string;
  password: string;
};

type LoginResponse = {
  token: string;
  [key: string]: any;
};

type UseLoginReturn = {
  credentials: Credentials;
  setCredentials: (c: Partial<Credentials>) => void;
  handleChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  login: () => Promise<LoginResponse | null>;
  logout: () => void;
  loading: boolean;
  error: string | null;
  isAuthenticated: boolean;
  token: string | null;
};

const TOKEN_KEY = "auth_token";

export default function useLogin(
  initial: Credentials = { email: "", password: "" }
): UseLoginReturn {
  const [credentials, setCredentialsState] = useState<Credentials>(initial);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [token, setToken] = useState<string | null>(() => {
    try {
      return localStorage.getItem(TOKEN_KEY);
    } catch {
      return null;
    }
  });

  const isAuthenticated = Boolean(token);

  const setCredentials = useCallback((c: Partial<Credentials>) => {
    setCredentialsState((prev) => ({ ...prev, ...c }));
  }, []);

  const handleChange = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setCredentials({ [name]: value } as Partial<Credentials>);
  }, [setCredentials]);

  const login = useCallback(async (): Promise<LoginResponse | null> => {
    setLoading(true);
    setError(null);

    try {
      const base = (process.env.REACT_APP_API_BASE_URL ?? "").replace(/\/$/, "");
      const res = await fetch(`${base}/auth/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(credentials),
      });

      const data = await res.json().catch(() => null);

      if (!res.ok) {
        const msg =
          (data && (data.message || data.error)) ||
          `Login failed with status ${res.status}`;
        setError(msg);
        setLoading(false);
        return null;
      }

      const loginData = data as LoginResponse;
      if (loginData?.token) {
        try {
          localStorage.setItem(TOKEN_KEY, loginData.token);
        } catch {
          // ignore localStorage errors
        }
        setToken(loginData.token);
      }

      setLoading(false);
      return loginData;
    } catch (err) {
      setError((err as Error)?.message ?? "Network error");
      setLoading(false);
      return null;
    }
  }, [credentials]);

  const logout = useCallback(() => {
    try {
      localStorage.removeItem(TOKEN_KEY);
    } catch {
      // ignore errors
    }
    setToken(null);
  }, []);

  // keep token in sync if it changes elsewhere
  useEffect(() => {
    const onStorage = (e: StorageEvent) => {
      if (e.key === TOKEN_KEY) {
        setToken(e.newValue);
      }
    };
    window.addEventListener("storage", onStorage);
    return () => window.removeEventListener("storage", onStorage);
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
    token,
  };
}