import { useState } from "react";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { signup } from "#/features/auth/api/authApi";
import type { SignUpResult, SignUpCredentials } from "#/features/auth/types/authTypes";
import { ApiError } from "#/shared/types/sharedTypes";

type UseSignupReturn = {
    credentials: SignUpCredentials;
    setCredentials: (c: Partial<SignUpCredentials>) => void;
    signup: () => Promise<SignUpResult>;
    loading: boolean;
    error: ApiError | null;
};

export default function useSignup(
    initial: SignUpCredentials = { email: "", password: "" }
): UseSignupReturn {
    const [credentials, setCredentialsState] = useState<SignUpCredentials>(initial);
    const queryClient = useQueryClient();

    const setCredentials = (c: Partial<SignUpCredentials>) => {
        setCredentialsState((prev) => ({ ...prev, ...c }));
    };

    const mutation = useMutation<SignUpResult, ApiError>({
        mutationFn: () => signup(credentials),

        onSuccess: async () => {
            await queryClient.invalidateQueries({ queryKey: ["auth", "me"] });
        },
    });

    return {
        credentials,
        setCredentials,
        signup: mutation.mutateAsync,
        loading: mutation.isPending,
        error: mutation.error
    };
}