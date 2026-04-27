
import { useQuery } from "@tanstack/react-query";
import { getUsers } from "#/features/users/api/usersApi";
import { type User } from "#/features/users/types/usersTypes";
import { type ApiError } from "#/shared/types/sharedTypes";

export function useUsers() {
    return useQuery<User[], ApiError>({
        queryKey: ["users"],
        queryFn: getUsers,
        staleTime: 1000 * 60, // 1 minute cache
    });
}