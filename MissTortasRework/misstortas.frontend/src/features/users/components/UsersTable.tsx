import { useMemo, useState } from 'react'
import { useUsers, useMe } from '#/features/users/hooks/useUsers'

export default function UsersTable() {
  const [search, setSearch] = useState('')
  const [roleFilter, setRoleFilter] = useState('')

  const { data: me, isPending: isCurrentUserPending } = useMe()
  const canViewUsers = !!me?.capabilities.canViewUsers
  const { data: users = [], isPending, error } = useUsers(canViewUsers)

  // derive all roles (for dropdown)
  const allRoles = useMemo(() => {
    const set = new Set<string>()
    users.forEach((u) => u.roles.forEach((r) => set.add(r)))
    return Array.from(set)
  }, [users])

  // filtered users
  const filteredUsers = useMemo(() => {
    return users.filter((u) => {
      const matchesSearch = u.username
        .toLowerCase()
        .includes(search.toLowerCase())

      const matchesRole = roleFilter ? u.roles.includes(roleFilter) : true

      return matchesSearch && matchesRole
    })
  }, [users, search, roleFilter])

  if (isCurrentUserPending) {
    return (
      <section className="rounded-2xl border border-slate-200 bg-white p-6 shadow-sm">
        <p className="text-sm text-slate-500">
          Checking your access to the users directory...
        </p>
      </section>
    )
  }

  if (!canViewUsers) {
    return (
      <section className="rounded-2xl border border-slate-200 bg-white p-6 shadow-sm">
        <h2 className="text-2xl font-semibold text-slate-900">
          Users directory
        </h2>
        <p className="mt-2 text-sm text-slate-500">
          Your profile is visible above, but your current permissions do not
          allow listing all users.
        </p>
      </section>
    )
  }

  if (isPending) {
    return (
      <section className="rounded-2xl border border-slate-200 bg-white p-6 shadow-sm">
        <p className="text-sm text-slate-500">Loading users...</p>
      </section>
    )
  }

  if (error) {
    return (
      <section className="rounded-2xl border border-rose-200 bg-rose-50 p-6 text-rose-700 shadow-sm">
        {error.message || 'Failed to load users'}
      </section>
    )
  }

  return (
    <section className="space-y-4 rounded-2xl border border-slate-200 bg-white p-6 shadow-sm">
      <h2 className="text-2xl font-semibold text-slate-900">Users directory</h2>

      {/* Filters */}
      <div className="flex gap-4">
        <input
          type="text"
          placeholder="Search by username..."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          className="border px-3 py-2 rounded w-64"
        />

        <select
          value={roleFilter}
          onChange={(e) => setRoleFilter(e.target.value)}
          className="border px-3 py-2 rounded"
        >
          <option value="">All roles</option>
          {allRoles.map((role) => (
            <option key={role} value={role}>
              {role}
            </option>
          ))}
        </select>

        <button
          onClick={() => {
            setSearch('')
            setRoleFilter('')
          }}
          className="bg-gray-200 px-3 py-2 rounded"
        >
          Reset
        </button>
      </div>

      {/* Table */}
      <table className="w-full border border-gray-300 rounded">
        <thead className="bg-gray-100">
          <tr>
            <th className="text-left px-4 py-2 border-b">ID</th>
            <th className="text-left px-4 py-2 border-b">Username</th>
            <th className="text-left px-4 py-2 border-b">Roles</th>
            <th className="text-left px-4 py-2 border-b">Enabled</th>
          </tr>
        </thead>

        <tbody>
          {filteredUsers.length === 0 ? (
            <tr>
              <td colSpan={4} className="text-center px-4 py-4 text-gray-500">
                No users found
              </td>
            </tr>
          ) : (
            filteredUsers.map((user) => (
              <tr key={user.id} className="border-t">
                <td className="px-4 py-2">{user.id}</td>
                <td className="px-4 py-2">{user.username}</td>
                <td className="px-4 py-2">{user.roles.join(', ')}</td>
                <td className="px-4 py-2">{user.enabled ? 'True' : 'False'}</td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </section>
  )
}
