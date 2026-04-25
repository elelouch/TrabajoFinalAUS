import { createFileRoute, useNavigate } from "@tanstack/react-router";
import SignUpForm from "#/features/auth/components/SignUpForm";

export const Route = createFileRoute("/signup")({
    component: SignupPage,
});

function SignupPage() {
    const navigate = useNavigate();

    return (
        <div className="min-h-screen flex items-center justify-center bg-gray-50">
            <div className="w-full max-w-md p-6 bg-white rounded-2xl shadow">
                <SignUpForm
                    onSuccess={() => {
                        navigate({ to: "/signin" });
                    }}
                />
            </div>
        </div>
    );
}