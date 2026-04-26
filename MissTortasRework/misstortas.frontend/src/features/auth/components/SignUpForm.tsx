import React, { useState } from "react";
import useSignup from "#/features/auth/hooks/useSignup";
import { useNavigate } from "@tanstack/react-router";
import { ApiError } from "#/features/auth/types/authTypes";

const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
const passwordRegex = /^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{10,}$/;

export interface SignUpFormsProps {
    onSuccess?: (credentials?: { email: string, password: string }) => void;
    initialEmail?: string;
    className?: string;
}

const SignUpForm: React.FC<SignUpFormsProps> = ({
    onSuccess,
    initialEmail = "",
    className,
}) => {
    const { credentials, setCredentials, signup, loading, error } = useSignup();

    const [errors, setErrors] = useState({
        email: "",
        password: "",
        general: "",
    });

    const validate = () => {
        const nextErrors = {
            email: credentials.email.trim()
                ? emailRegex.test(credentials.email)
                    ? ""
                    : "Invalid email."
                : "Email is required.",
            password: credentials.password
                ? passwordRegex.test(credentials.password)
                    ? ""
                    : "Password must be at least 10 characters, include an uppercase letter, a digit, and a special character."
                : "Password is required.",
            general: "",
        };

        setErrors(nextErrors);
        return !Object.values(nextErrors).some(Boolean);
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (!validate()) return;

        try {
            await signup();
            onSuccess?.(credentials);
        } catch (apiError: unknown) {
            if (apiError instanceof ApiError) {
                var apiErrorData = apiError.data;
                const nextErrors = {
                    email: "",
                    password: "",
                    general: apiErrorData.message as string
                };
                setErrors(nextErrors)
            }
        }
    };

    return (
        <form className={`space-y-6 ${className}`} onSubmit={handleSubmit} noValidate>
            <h2 className="text-2xl font-bold">Sign up</h2>

            {(errors.general) && (
                <div className="text-red-500">{errors.general}</div>
            )}

            <div className="flex flex-col space-y-2">
                <label htmlFor="signup-email" className="font-medium">Email</label>
                <input
                    id="signup-email"
                    type="email"
                    value={credentials.email}
                    onChange={(e) => setCredentials({ email: e.target.value })}
                    className={`border p-2 rounded ${errors.email ? "border-red-500" : "border-gray-300"
                        }`}
                    disabled={loading}
                />
                {errors.email && <div className="text-red-500 text-sm">{errors.email}</div>}
            </div>

            <div className="flex flex-col space-y-2">
                <label htmlFor="signup-password" className="font-medium">Password</label>
                <input
                    id="signup-password"
                    type="password"
                    value={credentials.password}
                    onChange={(e) => setCredentials({ password: e.target.value })}
                    className={`border p-2 rounded ${errors.password ? "border-red-500" : "border-gray-300"
                        }`}
                    disabled={loading}
                />
                {errors.password && (
                    <div className="text-red-500 text-sm">{errors.password}</div>
                )}
            </div>

            <div className="flex space-x-4">
                <button
                    type="submit"
                    className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600 disabled:bg-gray-400"
                    disabled={loading}
                >
                    {loading ? "Signing up…" : "Sign up"}
                </button>

                <button
                    type="button"
                    className="bg-gray-300 text-gray-700 px-4 py-2 rounded hover:bg-gray-400"
                    onClick={() => {
                        setCredentials({ email: "", password: "" });
                        setErrors({ email: "", password: "", general: "" });
                    }}
                    disabled={loading}
                >
                    Reset
                </button>
            </div>
        </form>
    );
};

export default SignUpForm;