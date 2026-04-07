import React, { useState, FormEvent } from 'react';
import { useNavigate } from 'react-router-dom';

/*
  SignUpPage
  - Simple sign up form with client-side validation
  - Submits to /api/auth/signup (adjust endpoint to your backend)
  - On success navigates to sign-in page
*/

type FormState = {
  fullName: string;
  email: string;
  password: string;
  confirmPassword: string;
};

export default function SignUpPage(): JSX.Element {
  const [form, setForm] = useState<FormState>({
    fullName: '',
    email: '',
    password: '',
    confirmPassword: '',
  });
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const update = (key: keyof FormState, value: string) =>
    setForm(prev => ({ ...prev, [key]: value }));

  const validate = (): string | null => {
    if (!form.fullName.trim()) return 'Full name is required.';
    if (!form.email.trim()) return 'Email is required.';
    const emailRe = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRe.test(form.email)) return 'Invalid email address.';
    if (form.password.length < 6) return 'Password must be at least 6 characters.';
    if (form.password !== form.confirmPassword) return 'Passwords do not match.';
    return null;
  };

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();
    setError(null);
    const validationError = validate();
    if (validationError) {
      setError(validationError);
      return;
    }

    setLoading(true);
    try {
      const res = await fetch('/api/auth/signup', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          name: form.fullName,
          email: form.email,
          password: form.password,
        }),
      });

      if (!res.ok) {
        const payload = await res.json().catch(() => null);
        const message = payload?.message || `Signup failed: ${res.statusText}`;
        setError(message);
        setLoading(false);
        return;
      }

      // Successful sign-up: redirect to sign-in (adjust route as needed)
      navigate('/auth/signin', { replace: true });
    } catch (err) {
      setError('Network error. Please try again.');
      setLoading(false);
    }
  };

  return (
    <div className="auth-page" style={{ maxWidth: 480, margin: '2rem auto', padding: '1.5rem', border: '1px solid #e6e6e6', borderRadius: 8 }}>
      <h2 style={{ marginBottom: '0.5rem' }}>Create an account</h2>
      <p style={{ color: '#666', marginTop: 0 }}>Sign up to start ordering your favorite tortas.</p>

      <form onSubmit={handleSubmit} noValidate>
        <div style={{ marginBottom: '0.75rem' }}>
          <label htmlFor="fullName">Full name</label>
          <input
            id="fullName"
            type="text"
            value={form.fullName}
            onChange={e => update('fullName', e.target.value)}
            required
            style={{ width: '100%', padding: '0.5rem', marginTop: '0.25rem' }}
          />
        </div>

        <div style={{ marginBottom: '0.75rem' }}>
          <label htmlFor="email">Email</label>
          <input
            id="email"
            type="email"
            value={form.email}
            onChange={e => update('email', e.target.value)}
            required
            style={{ width: '100%', padding: '0.5rem', marginTop: '0.25rem' }}
          />
        </div>

        <div style={{ marginBottom: '0.75rem' }}>
          <label htmlFor="password">Password</label>
          <input
            id="password"
            type="password"
            value={form.password}
            onChange={e => update('password', e.target.value)}
            required
            style={{ width: '100%', padding: '0.5rem', marginTop: '0.25rem' }}
          />
        </div>

        <div style={{ marginBottom: '0.75rem' }}>
          <label htmlFor="confirmPassword">Confirm password</label>
          <input
            id="confirmPassword"
            type="password"
            value={form.confirmPassword}
            onChange={e => update('confirmPassword', e.target.value)}
            required
            style={{ width: '100%', padding: '0.5rem', marginTop: '0.25rem' }}
          />
        </div>

        {error && (
          <div role="alert" style={{ color: '#c00', marginBottom: '0.75rem' }}>
            {error}
          </div>
        )}

        <div style={{ display: 'flex', gap: '0.5rem', alignItems: 'center' }}>
          <button type="submit" disabled={loading} style={{ padding: '0.6rem 1rem' }}>
            {loading ? 'Creating...' : 'Create account'}
          </button>

          <button
            type="button"
            onClick={() => navigate('/auth/signin')}
            style={{ padding: '0.6rem 1rem', background: 'transparent', border: '1px solid #ccc' }}
          >
            Already have an account?
          </button>
        </div>
      </form>
    </div>
  );
}