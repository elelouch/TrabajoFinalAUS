
import React, { useState } from "react";
import useSignin from "#/features/auth/hooks/useSignin";

export interface LoginCredentials {
    email: string;
    password: string;
}

export interface LoginFormProps {
    /**
     * Called on successful login with the resolved access token.
     */
    onSuccess?: (credentials?: { email: string, password: string }) => void;
    initialEmail?: string;
    className?: string;
}

const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

const LoginForm: React.FC<LoginFormProps> = ({
    onSuccess,
    initialEmail = "",
    className,
}) => {
    const { credentials, setCredentials, signin, loading, error } = useSignin({
        email: initialEmail,
        password: "",
    });

    const [errors, setErrors] = useState({ email: "", password: "", general: "" });
    const isSubmitting = loading;

    const email = credentials.email;
    const password = credentials.password;

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

        try {
            await signin();
            onSuccess?.();
        } catch (err) {
            // Set a user-friendly error message
            setErrors((prev) => ({ ...prev, general: "Login failed. Please try again." }));
        }
    };

    return (
        <form className={`space-y-4 ${className ?? ""}`} onSubmit={handleSubmit} noValidate>
            <h2 className="text-2xl font-semibold">Sign in</h2>

            {errors.general && <div className="text-red-600">{errors.general}</div>}

            <div className="flex flex-col">
                <label htmlFor="login-email" className="text-sm font-medium">Email</label>
                <input
                    id="login-email"
                    type="email"
                    value={email}
                    onChange={(e) => setCredentials({ email: e.target.value })}
                    className={`border rounded px-3 py-2 ${errors.email ? "border-red-500" : "border-gray-300"}`}
                    disabled={isSubmitting}
                />
                {errors.email && <div className="text-red-500 text-sm">{errors.email}</div>}
            </div>

            <div className="flex flex-col">
                <label htmlFor="login-password" className="text-sm font-medium">Password</label>
                <input
                    id="login-password"
                    type="password"
                    value={password}
                    onChange={(e) => setCredentials({ password: e.target.value })}
                    className={`border rounded px-3 py-2 ${errors.password ? "border-red-500" : "border-gray-300"}`}
                    disabled={isSubmitting}
                />
                {errors.password && <div className="text-red-500 text-sm">{errors.password}</div>}
            </div>

            <div className="flex items-center space-x-3">
                <button
                    type="submit"
                    disabled={isSubmitting}
                    className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 disabled:opacity-60"
                >
                    {isSubmitting ? "Signing in…" : "Sign in"}
                </button>

                <button
                    type="button"
                    onClick={() => {
                        setCredentials({ email: "", password: "" });
                        setErrors({ email: "", password: "", general: "" });
                    }}
                    disabled={isSubmitting}
                    className="bg-gray-200 text-gray-800 px-3 py-2 rounded"
                >
                    Reset
                </button>
            </div>
        </form>
    );
};

export default LoginForm;