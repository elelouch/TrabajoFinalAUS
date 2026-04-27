import { createFileRoute } from '@tanstack/react-router'
import UsersTable from '#/features/users/components/UsersTable'

export const Route = createFileRoute('/users/')({
    component: UsersPage,
})

function UsersPage() {
    return (
        <div>
            <UsersTable />
        </div>
    )
}