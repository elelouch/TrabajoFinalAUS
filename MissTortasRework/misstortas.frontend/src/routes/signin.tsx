import { createFileRoute, useNavigate } from '@tanstack/react-router';
import SignInForm from '#/features/auth/components/SignInForm';

export const Route = createFileRoute('/signin')({
    component: SignInPage,
});

function SignInPage() {
    const navigate = useNavigate();

    return (
        <div className="min-h-screen flex items-center justify-center bg-gray-50">
            <div className="w-full max-w-md p-6 bg-white rounded-2xl shadow">
                <SignInForm
                    onSuccess={() => {navigate({ to: '/' });
                    }}
                />
            </div>
        </div>
    );
}