import { useMe } from '#/features/users/hooks/useUsers'

function formatLabel(value: string) {
  return value
    .replace(/([a-z0-9])([A-Z])/g, '$1 $2')
    .replace(/[_-]+/g, ' ')
    .replace(/^./, (char) => char.toUpperCase())
}

function formatCapabilityValue(value: unknown) {
  if (typeof value === 'boolean') {
    return value ? 'Allowed' : 'Denied'
  }

  if (Array.isArray(value)) {
    return value.length > 0 ? value.join(', ') : 'None'
  }

  if (value === null || value === undefined || value === '') {
    return 'Not set'
  }

  if (typeof value === 'object') {
    return JSON.stringify(value)
  }

  return String(value)
}

export default function CurrentUserProfile() {
  const { data: me, isPending, error } = useMe()

  if (isPending) {
    return (
      <section className="rounded-2xl border border-slate-200 bg-white p-6 shadow-sm">
        <p className="text-sm text-slate-500">
          Loading current user profile...
        </p>
      </section>
    )
  }

  if (error) {
    return (
      <section className="rounded-2xl border border-rose-200 bg-rose-50 p-6 text-rose-700 shadow-sm">
        <h2 className="text-lg font-semibold">Current user profile</h2>
        <p className="mt-2 text-sm">
          {error.message || 'Unable to load your profile.'}
        </p>
      </section>
    )
  }

  if (!me) {
    return (
      <section className="rounded-2xl border border-slate-200 bg-white p-6 shadow-sm">
        <h2 className="text-lg font-semibold text-slate-900">
          Current user profile
        </h2>
        <p className="mt-2 text-sm text-slate-500">
          Sign in to inspect your current roles and permissions.
        </p>
      </section>
    )
  }

  const capabilityEntries = Object.entries(me.capabilities ?? {}).sort(
    ([left], [right]) => left.localeCompare(right),
  )

  return (
    <section
      id="current-user-profile"
      className="rounded-2xl border border-slate-200 bg-white p-6 shadow-sm"
    >
      <div className="flex flex-col gap-4 md:flex-row md:items-start md:justify-between">
        <div>
          <p className="text-sm font-medium uppercase tracking-[0.2em] text-slate-500">
            Current user
          </p>
          <h2 className="mt-2 text-2xl font-semibold text-slate-900">
            {me.username}
          </h2>
          <p className="mt-1 text-sm text-slate-500">
            App user id:{' '}
            <span className="font-mono text-slate-700">{me.appUserId}</span>
          </p>
        </div>

        <div className="rounded-xl bg-slate-900 px-4 py-3 text-white">
          <p className="text-xs uppercase tracking-[0.2em] text-slate-300">
            Internal id
          </p>
          <p className="mt-1 text-2xl font-semibold">{me.userId}</p>
        </div>
      </div>

      <div className="mt-6 grid gap-6 lg:grid-cols-[minmax(0,1fr)_minmax(0,1.2fr)]">
        <div>
          <h3 className="text-sm font-semibold uppercase tracking-[0.16em] text-slate-500">
            Roles
          </h3>
          <div className="mt-3 flex flex-wrap gap-2">
            {me.roles.length > 0 ? (
              me.roles.map((role) => (
                <span
                  key={role}
                  className="rounded-full border border-amber-300 bg-amber-50 px-3 py-1 text-sm font-medium text-amber-800"
                >
                  {role}
                </span>
              ))
            ) : (
              <span className="text-sm text-slate-500">No roles assigned.</span>
            )}
          </div>
        </div>

        <div>
          <h3 className="text-sm font-semibold uppercase tracking-[0.16em] text-slate-500">
            Capabilities
          </h3>

          {capabilityEntries.length > 0 ? (
            <div className="mt-3 overflow-hidden rounded-xl border border-slate-200">
              <dl className="divide-y divide-slate-200">
                {capabilityEntries.map(([key, value]) => (
                  <div
                    key={key}
                    className="grid gap-2 bg-slate-50 px-4 py-3 sm:grid-cols-[minmax(0,180px)_minmax(0,1fr)] sm:items-center"
                  >
                    <dt className="text-sm font-medium text-slate-700">
                      {formatLabel(key)}
                    </dt>
                    <dd className="text-sm text-slate-600 break-all">
                      {formatCapabilityValue(value)}
                    </dd>
                  </div>
                ))}
              </dl>
            </div>
          ) : (
            <p className="mt-3 text-sm text-slate-500">
              No capabilities were returned.
            </p>
          )}
        </div>
      </div>
    </section>
  )
}
