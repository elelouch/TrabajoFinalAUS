import React, { useMemo, useState } from "react";
import { useUsers } from "#/features/users/hooks/useUsers";

export default function UsersTable() {
    const { data: users = [], isPending, error } = useUsers();

    const [search, setSearch] = useState("");
    const [roleFilter, setRoleFilter] = useState("");

    // derive all roles (for dropdown)
    const allRoles = useMemo(() => {
        const set = new Set<string>();
        users.forEach((u) => u.roles.forEach((r) => set.add(r)));
        return Array.from(set);
    }, [users]);

    // filtered users
    const filteredUsers = useMemo(() => {
        return users.filter((u) => {
            const matchesSearch = u.username
                .toLowerCase()
                .includes(search.toLowerCase());

            const matchesRole = roleFilter
                ? u.roles.includes(roleFilter)
                : true;

            return matchesSearch && matchesRole;
        });
    }, [users, search, roleFilter]);

    if (isPending) return <div>Loading users...</div>;

    if (error) {
        return (
            <div className="text-red-500">
                {error.message || "Failed to load users"}
            </div>
        );
    }

    return (
        <div className="space-y-4">
            <h2 className="text-2xl font-semibold">Users</h2>

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
                        setSearch("");
                        setRoleFilter("");
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
                    </tr>
                </thead>

                <tbody>
                    {filteredUsers.length === 0 ? (
                        <tr>
                            <td
                                colSpan={3}
                                className="text-center px-4 py-4 text-gray-500"
                            >
                                No users found
                            </td>
                        </tr>
                    ) : (
                        filteredUsers.map((user) => (
                            <tr key={user.id} className="border-t">
                                <td className="px-4 py-2">{user.id}</td>
                                <td className="px-4 py-2">{user.username}</td>
                                <td className="px-4 py-2">
                                    {user.roles.join(", ")}
                                </td>
                            </tr>
                        ))
                    )}
                </tbody>
            </table>
        </div>
    );
}