import { createFileRoute } from '@tanstack/react-router'
import CurrentUserProfile from '#/features/users/components/CurrentUserProfile'
import UsersTable from '#/features/users/components/UsersTable'

export const Route = createFileRoute('/users/')({
  component: UsersPage,
})

function UsersPage() {
  return (
    <div className="space-y-6">
      <CurrentUserProfile />
      <UsersTable />
    </div>
  )
}
