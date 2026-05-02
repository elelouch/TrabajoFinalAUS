import { createFileRoute } from '@tanstack/react-router'
import CurrentUserProfile from '#/features/users/components/CurrentUserProfile'

export const Route = createFileRoute('/')({
  component: Home,
})

function Home() {
  return (
    <div className="space-y-6 p-8">
      <div>
        <h1 className="text-4xl font-bold text-slate-900">
          Welcome to MissTortas
        </h1>
        <p className="mt-4 max-w-2xl text-lg text-slate-600">
          This dashboard now reads your <code>/users/me</code> payload and shows
          the current identity, roles, and capabilities returned by the API.
        </p>
      </div>

      <CurrentUserProfile />
    </div>
  )
}
