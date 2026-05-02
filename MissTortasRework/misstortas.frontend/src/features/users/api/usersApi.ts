import type {
  CurrentUser,
  UpdateUser,
  User,
  UserConsultancies,
} from '#/features/users/types/usersTypes'
import apiClient from '#/shared/api/apiClient'

export async function getUsers(): Promise<User[]> {
  return apiClient('/users', {
    method: 'GET',
    auth: true,
  })
}

/**
 * PUT /users/{userId}
 */
export async function updateUser(
  userId: string,
  data: UpdateUser,
): Promise<void> {
  return apiClient(`/users/${userId}`, {
    method: 'PUT',
    body: JSON.stringify(data),
    auth: true,
  })
}

/**
 * GET /users/{userId}/consultancies
 */
export async function getUserConsultancies(
  userId: number,
): Promise<UserConsultancies[]> {
  return apiClient(`/users/${userId}/consultancies`, {
    method: 'GET',
    auth: true,
  })
}

export async function getMe(): Promise<CurrentUser> {
  return apiClient(`/users/me`, {
    method: 'GET',
    auth: true,
  })
}
