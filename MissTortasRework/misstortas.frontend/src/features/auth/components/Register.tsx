import React, { useState } from "react";
import { signUp } from "../services/authService";

const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
const passwordRegex = /^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{10,}$/; // Matches the password policy

const SignUpForm: React.FC<{ className?: string }> = ({ className }) => {
  const [form, setForm] = useState({ name: "", email: "", password: "" });
  const [errors, setErrors] = useState({ name: "", email: "", password: "", general: "" });
  const [isSubmitting, setIsSubmitting] = useState(false);

  const validate = () => {
    const nextErrors = {
      name: form.name.trim() ? "" : "Name is required.",
      email: form.email.trim() ? (emailRegex.test(form.email) ? "" : "Invalid email.") : "Email is required.",
      password: form.password
        ? passwordRegex.test(form.password)
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

    setIsSubmitting(true);
    try {
      const result = await signUp(form);
      if (result.identityResult?.succeeded) {
        alert("Account created successfully!");
      } else {
        setErrors((prev) => ({ ...prev, general: "Sign-up failed. Please try again." }));
      }
    } catch (err: any) {
      setErrors((prev) => ({ ...prev, general: err.message || "Sign-up failed." }));
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <form className={`space-y-6 ${className}`} onSubmit={handleSubmit} noValidate>
      <h2 className="text-2xl font-bold">Sign up</h2>
      {errors.general && <div className="text-red-500">{errors.general}</div>}

      <div className="flex flex-col space-y-2">
        <label htmlFor="signup-name" className="font-medium">Name</label>
        <input
          id="signup-name"
          type="text"
          value={form.name}
          onChange={(e) => setForm((prev) => ({ ...prev, name: e.target.value }))}
          className={`border p-2 rounded ${errors.name ? "border-red-500" : "border-gray-300"}`}
          disabled={isSubmitting}
        />
        {errors.name && <div className="text-red-500 text-sm">{errors.name}</div>}
      </div>

      <div className="flex flex-col space-y-2">
        <label htmlFor="signup-email" className="font-medium">Email</label>
        <input
          id="signup-email"
          type="email"
          value={form.email}
          onChange={(e) => setForm((prev) => ({ ...prev, email: e.target.value }))}
          className={`border p-2 rounded ${errors.email ? "border-red-500" : "border-gray-300"}`}
          disabled={isSubmitting}
        />
        {errors.email && <div className="text-red-500 text-sm">{errors.email}</div>}
      </div>

      <div className="flex flex-col space-y-2">
        <label htmlFor="signup-password" className="font-medium">Password</label>
        <input
          id="signup-password"
          type="password"
          value={form.password}
          onChange={(e) => setForm((prev) => ({ ...prev, password: e.target.value }))}
          className={`border p-2 rounded ${errors.password ? "border-red-500" : "border-gray-300"}`}
          disabled={isSubmitting}
        />
        {errors.password && <div className="text-red-500 text-sm">{errors.password}</div>}
      </div>

      <div className="flex space-x-4">
        <button
          type="submit"
          className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600 disabled:bg-gray-400"
          disabled={isSubmitting}
        >
          {isSubmitting ? "Signing up…" : "Sign up"}
        </button>
        <button
          type="button"
          className="bg-gray-300 text-gray-700 px-4 py-2 rounded hover:bg-gray-400"
          onClick={() => setForm({ name: "", email: "", password: "" })}
          disabled={isSubmitting}
        >
          Reset
        </button>
      </div>
    </form>
  );
};

export default SignUpForm;