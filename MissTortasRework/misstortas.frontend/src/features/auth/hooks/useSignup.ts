import { useCallback, useEffect, useRef, useState } from "react";

export interface SignupData {
  name: string;
  email: string;
  password: string;
  confirmPassword?: string;
}

export interface SignupResult {
  user?: any;
  token?: string;
  message?: string;
}

export interface UseSignupReturn {
  values: SignupData;
  setField: (field: keyof SignupData, value: string) => void;
  handleChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  submit: (override?: Partial<SignupData>) => Promise<SignupResult | null>;
  isLoading: boolean;
  isSuccess: boolean;
  error: string | null;
  reset: () => void;
}

const API_BASE = process.env.REACT_APP_API_URL || "";

function validate(values: SignupData): string | null {
  if (!values.name?.trim()) return "Name is required.";
  if (!values.email?.trim()) return "Email is required.";
  // simple email check
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (!emailRegex.test(values.email)) return "Email is invalid.";
  if (!values.password) return "Password is required.";
  if (values.password.length < 6) return "Password must be at least 6 characters.";
  if (values.confirmPassword !== undefined && values.password !== values.confirmPassword)
    return "Passwords do not match.";
  return null;
}

export default function useSignup(initial?: Partial<SignupData>): UseSignupReturn {
  const [values, setValues] = useState<SignupData>({
    name: "",
    email: "",
    password: "",
    confirmPassword: "",
    ...(initial || {}),
  });

  const [isLoading, setIsLoading] = useState(false);
  const [isSuccess, setIsSuccess] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const abortRef = useRef<AbortController | null>(null);
  const mountedRef = useRef(true);

  useEffect(() => {
    mountedRef.current = true;
    return () => {
      mountedRef.current = false;
      if (abortRef.current) abortRef.current.abort();
    };
  }, []);

  const setField = useCallback((field: keyof SignupData, value: string) => {
    setValues((prev) => ({ ...prev, [field]: value }));
  }, []);

  const handleChange = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setValues((prev) => ({ ...prev, [name as keyof SignupData]: value }));
  }, []);

  const submit = useCallback(
    async (override?: Partial<SignupData>): Promise<SignupResult | null> => {
      const payload: SignupData = { ...values, ...(override || {}) };
      setError(null);
      const validationError = validate(payload);
      if (validationError) {
        setError(validationError);
        setIsSuccess(false);
        return null;
      }

      setIsLoading(true);
      setIsSuccess(false);

      if (abortRef.current) abortRef.current.abort();
      const ac = new AbortController();
      abortRef.current = ac;

      try {
        const res = await fetch(`${API_BASE}/auth/signup`, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            name: payload.name,
            email: payload.email,
            password: payload.password,
          }),
          signal: ac.signal,
        });

        const data = await (res.headers.get("content-type")?.includes("application/json")
          ? res.json()
          : Promise.resolve({ message: await res.text() }));

        if (!mountedRef.current) return null;

        if (!res.ok) {
          const msg = (data && (data.message || data.error)) || "Signup failed.";
          setError(typeof msg === "string" ? msg : JSON.stringify(msg));
          setIsLoading(false);
          setIsSuccess(false);
          return null;
        }

        setIsSuccess(true);
        setIsLoading(false);
        setError(null);

        // Optionally persist token/user as needed by the app:
        // if (data.token) localStorage.setItem('token', data.token);

        return { user: data.user, token: data.token, message: data.message };
      } catch (err: any) {
        if (!mountedRef.current) return null;
        if (err.name === "AbortError") {
          setError("Request was cancelled.");
        } else {
          setError(err?.message ?? "Network error.");
        }
        setIsLoading(false);
        setIsSuccess(false);
        return null;
      }
    },
    [values]
  );

  const reset = useCallback(() => {
    setValues({
      name: "",
      email: "",
      password: "",
      confirmPassword: "",
    });
    setIsLoading(false);
    setIsSuccess(false);
    setError(null);
    if (abortRef.current) abortRef.current.abort();
  }, []);

  return {
    values,
    setField,
    handleChange,
    submit,
    isLoading,
    isSuccess,
    error,
    reset,
  };
}