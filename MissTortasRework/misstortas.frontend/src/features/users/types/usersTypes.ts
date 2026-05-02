export type User = {
  id: string
  username: string
  roles: string[]
  enabled: boolean
}

export type UpdateUser = {
  username: string
  email: string
  enabled: boolean
  roles: string[]
}

export type UserConsultancies = {
  id: number
  // add other fields from backend
}

export type UserCapabilities = {
  canViewUsers?: boolean
} & Record<string, unknown>

export type UserMetadata = {
  roles: string[]
  userId: number
  appUserId: string
  username: string
  capabilities: UserCapabilities
}

export type UserData = UserMetadata

export type CurrentUser = {
  userData: UserMetadata
}
