import { useMutation, useQueryClient } from "@tanstack/react-query";
import { signin } from "#/features/auth/api/authApi";
import type { SignInCredentials, SignInResult } from "#/features/auth/types/authTypes";
import type { ApiError } from "#/shared/types/sharedTypes"
import { useState } from "react";
import { QUERY_USERS_ME } from "#/features/users/hooks/useUsers";

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
            await queryClient.invalidateQueries({ queryKey: QUERY_USERS_ME });
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