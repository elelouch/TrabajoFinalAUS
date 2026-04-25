import { useMutation, useQueryClient } from "@tanstack/react-query";
import { signin } from "#/features/auth/api/auth.ts";
import type { LoginCredentials, LoginResult } from "#/features/auth/types/authTypes";
import { useState } from "react";

type UseSigninReturn = {
    credentials: LoginCredentials;
    setCredentials: (c: Partial<LoginCredentials>) => void;
    signin: () => Promise<LoginResult>;
    loading: boolean;
    error: string | null;
};

export default function useSignin(
    initial: LoginCredentials = { email: "", password: "" }
): UseSigninReturn {
    const [credentials, setCredentialsState] = useState<LoginCredentials>(initial);
    const queryClient = useQueryClient();

    const setCredentials = (c: Partial<LoginCredentials>) => {
        setCredentialsState((prev) => ({ ...prev, ...c }));
    };

    const mutation = useMutation({
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