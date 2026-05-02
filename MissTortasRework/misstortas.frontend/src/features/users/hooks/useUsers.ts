import type { UserData } from '#/features/users/types/usersTypes'
import { useQuery } from '@tanstack/react-query'
import { getUsers, getMe } from '#/features/users/api/usersApi'
import { type User } from '#/features/users/types/usersTypes'
import { type ApiError } from '#/shared/types/sharedTypes'

export const QUERY_USERS_ME = ['users', 'me']
export const QUERY_USERS = ['users']

export function useUsers(enabled = true) {
  return useQuery<User[], ApiError>({
    queryKey: QUERY_USERS,
    queryFn: getUsers,
    enabled,
    staleTime: 1000 * 60, // 1 minute cache
  })
}
export function useMe() {
  return useQuery<UserData, ApiError>({
    queryKey: QUERY_USERS_ME,
    queryFn: async () => {
      const sape = await getMe()
      return sape.userData
    },

    staleTime: 1000 * 60, // 1 minute

    // Important for auth-related data:
    refetchOnWindowFocus: true,

    // Optional but useful:
    retry: false, // don't spam retries if unauthorized
  })
}
