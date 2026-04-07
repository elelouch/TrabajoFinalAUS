import React, { useState } from "react";
import apiClient from "../../../shared/api/apiClient";

export interface LoginCredentials {
  email: string;
  password: string;
}

export interface LoginFormProps {
  onSubmit: (credentials: LoginCredentials) => Promise<void>;
  initialEmail?: string;
  className?: string;
}

const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

const LoginForm: React.FC<LoginFormProps> = ({
  onSubmit,
  initialEmail = "",
  className,
}) => {
  const [email, setEmail] = useState(initialEmail);
  const [password, setPassword] = useState("");
  const [errors, setErrors] = useState({ email: "", password: "", general: "" });
  const [isSubmitting, setIsSubmitting] = useState(false);

  const validate = () => {
    const nextErrors = {
      email: email.trim() ? (emailRegex.test(email) ? "" : "Invalid email.") : "Email is required.",
      password: password ? (password.length >= 8 ? "" : "Password must be at least 8 characters.") : "Password is required.",
      general: "",
    };
    setErrors(nextErrors);
    return !Object.values(nextErrors).some(Boolean);
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!validate()) return;

    setIsSubmitting(true);
    try {
      await onSubmit({ email, password });
    } catch (err: any) {
      setErrors((prev) => ({ ...prev, general: err.message || "Login failed." }));
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <form className={`auth-form ${className}`} onSubmit={handleSubmit} noValidate>
      <h2>Sign in</h2>
      {errors.general && <div className="error-message">{errors.general}</div>}

      <div className="form-group">
        <label htmlFor="login-email">Email</label>
        <input
          id="login-email"
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          className={errors.email ? "invalid" : ""}
          disabled={isSubmitting}
        />
        {errors.email && <div className="error-message">{errors.email}</div>}
      </div>

      <div className="form-group">
        <label htmlFor="login-password">Password</label>
        <input
          id="login-password"
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          className={errors.password ? "invalid" : ""}
          disabled={isSubmitting}
        />
        {errors.password && <div className="error-message">{errors.password}</div>}
      </div>

      <div className="form-actions">
        <button type="submit" disabled={isSubmitting}>
          {isSubmitting ? "Signing in…" : "Sign in"}
        </button>
        <button
          type="button"
          onClick={() => {
            setEmail("");
            setPassword("");
            setErrors({ email: "", password: "", general: "" });
          }}
          disabled={isSubmitting}
        >
          Reset
        </button>
      </div>
    </form>
  );
};

export default LoginForm;