import { useMutation, useQueryClient } from "@tanstack/react-query";
import { signin } from "#/features/auth/api/authApi";
import type { ApiError, SignInCredentials, SignInResult } from "#/features/auth/types/authTypes";
import { useState } from "react";

type UseSigninReturn = {
    credentials: SignInCredentials;
    setCredentials: (c: Partial<SignInCredentials>) => void;
    signin: () => Promise<SignInResult>;
    loading: boolean;
    error: string | null;
};

export default function useSignin(
    initial: SignInCredentials = { email: "", password: "" }
): UseSigninReturn {
    const [credentials, setCredentialsState] = useState<SignInCredentials>(initial);
    const queryClient = useQueryClient();

    const setCredentials = (c: Partial<SignInCredentials>) => {
        setCredentialsState((prev) => ({ ...prev, ...c }));
    };

    const mutation = useMutation<SignInResult, ApiError>({
        mutationFn: () => signin(credentials),

        onSuccess: async () => {
            // 🔥 critical for cookie auth:
            // refetch current user after login
            await queryClient.invalidateQueries({ queryKey: ["auth", "me"] });
        },
    });

    return {
        credentials,
        setCredentials,
        signin: mutation.mutateAsync,
        loading: mutation.isPending,
        error: mutation.error instanceof Error ? mutation.error.message : null,
    };
}