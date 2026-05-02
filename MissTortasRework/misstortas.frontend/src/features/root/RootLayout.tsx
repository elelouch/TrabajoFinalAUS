import { Link, Outlet } from '@tanstack/react-router'
import { useMe } from '#/features/users/hooks/useUsers'
import { UsersLink } from '#/features/root/UsersLink'

export function RootLayout() {
  const { data: me } = useMe()

  const canViewUsers = !!me?.capabilities.canViewUsers
  return (
    <div>
      <nav className="flex items-center justify-between px-8 py-4 bg-gray-100 border-b">
        <h1 className="text-xl font-semibold"> MissTortas </h1>
        <div className="flex space-x-4">
          <Link
            to="/"
            hash="current-user-profile"
            className="text-blue-600 hover:underline"
          >
            My Profile
          </Link>
          {canViewUsers && <UsersLink />}
          <Link to="/signin" className="text-blue-600 hover:underline">
            Sign In
          </Link>
          <Link to="/signup" className="text-blue-600 hover:underline">
            Sign Up
          </Link>
        </div>
      </nav>

      {/* Page content */}
      <div className="p-8">
        <Outlet />
      </div>
    </div>
  )
}
