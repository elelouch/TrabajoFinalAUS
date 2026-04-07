import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

type LoginForm = {
  email: string;
  password: string;
};

const initialForm: LoginForm = {
  email: "",
  password: "",
};

export default function LoginPage(): JSX.Element {
  const [form, setForm] = useState<LoginForm>(initialForm);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

  function handleChange(e: React.ChangeEvent<HTMLInputElement>) {
    const { name, value } = e.target;
    setForm((s) => ({ ...s, [name]: value }));
  }

  function validate(): string | null {
    if (!form.email.trim()) return "Email is required.";
    if (!/\S+@\S+\.\S+/.test(form.email)) return "Email is invalid.";
    if (!form.password) return "Password is required.";
    if (form.password.length < 6) return "Password must be at least 6 characters.";
    return null;
  }

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();
    setError(null);

    const validationError = validate();
    if (validationError) {
      setError(validationError);
      return;
    }

    setLoading(true);
    try {
      const resp = await fetch("/api/auth/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ email: form.email, password: form.password }),
      });

      if (!resp.ok) {
        const payload = await resp.json().catch(() => null);
        throw new Error(payload?.message ?? "Authentication failed");
      }

      const data = (await resp.json()) as { token?: string; user?: Record<string, unknown> };
      if (data.token) {
        // store token and navigate to protected area
        localStorage.setItem("auth_token", data.token);
      }

      // optional: store user info
      if (data.user) {
        localStorage.setItem("auth_user", JSON.stringify(data.user));
      }

      navigate("/"); // adjust target route as needed
    } catch (err: unknown) {
      setError(err instanceof Error ? err.message : "An unexpected error occurred");
    } finally {
      setLoading(false);
    }
  }

  return (
    <div style={{ maxWidth: 420, margin: "40px auto", padding: 20 }}>
      <h1>Sign in</h1>

      <form onSubmit={handleSubmit} noValidate>
        <div style={{ marginBottom: 12 }}>
          <label htmlFor="email" style={{ display: "block", marginBottom: 6 }}>
            Email
          </label>
          <input
            id="email"
            name="email"
            type="email"
            value={form.email}
            onChange={handleChange}
            placeholder="you@example.com"
            required
            style={{ width: "100%", padding: 8, boxSizing: "border-box" }}
            aria-invalid={!!error && error.toLowerCase().includes("email")}
          />
        </div>

        <div style={{ marginBottom: 12 }}>
          <label htmlFor="password" style={{ display: "block", marginBottom: 6 }}>
            Password
          </label>
          <input
            id="password"
            name="password"
            type="password"
            value={form.password}
            onChange={handleChange}
            placeholder="••••••••"
            required
            style={{ width: "100%", padding: 8, boxSizing: "border-box" }}
            aria-invalid={!!error && error.toLowerCase().includes("password")}
          />
        </div>

        {error && (
          <div role="alert" style={{ color: "crimson", marginBottom: 12 }}>
            {error}
          </div>
        )}

        <button type="submit" disabled={loading} style={{ padding: "10px 14px" }}>
          {loading ? "Signing in..." : "Sign in"}
        </button>
      </form>
    </div>
  );
}