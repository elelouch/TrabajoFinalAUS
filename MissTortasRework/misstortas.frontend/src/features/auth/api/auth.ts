/**
 * Authentication contracts (requests/responses) used across the frontend.
 * Keep these interfaces minimal and serializable for HTTP transport.
 */

/**
 * Common token payload returned by the API.
 */
export interface TokenPayload {
  accessToken: string;
  refreshToken?: string;
  tokenType?: string;
  expiresIn?: number; // seconds until expiration
}

/**
 * Basic user profile returned alongside tokens.
 */
export interface UserProfile {
  id: string;
  email: string;
  fullName?: string;
  roles?: string[];
  // Any additional metadata coming from the backend
  [key: string]: any;
}

/**
 * Request payload for logging in.
 */
export interface LoginRequest {
  email: string;
  password: string;
  /**
   * If true, instructs the backend to issue long-lived tokens / remember the session.
   * Optional because not all endpoints require it.
   */
  remember?: boolean;
}

/**
 * Response payload for successful authentication (login/register/refresh).
 */
export interface AuthSuccessResponse {
  token: TokenPayload;
  user: UserProfile;
}

/**
 * Request payload for user registration.
 */
export interface RegisterRequest {
  email: string;
  password: string;
  fullName?: string;
  // Accept extras to allow backend-specific fields without breaking the contract
  [key: string]: any;
}

/**
 * Response payload for registration.
 */
export interface RegisterResponse extends AuthSuccessResponse {}

/**
 * Request payload to refresh tokens.
 */
export interface RefreshTokenRequest {
  refreshToken: string;
}

/**
 * Response payload for refresh token endpoint.
 */
export interface RefreshTokenResponse extends AuthSuccessResponse {}

/**
 * Standardized error shape from auth-related endpoints.
 */
export interface AuthError {
  code?: string;
  message: string;
  // Optional map of field errors (e.g. validation errors)
  fieldErrors?: Record<string, string[]>;
  // Raw details if available
  details?: any;
}


export interface SignUpCredentials {
    name: string;
    email: string;
    password: string;
}

export interface LoginCredentials {
    email: string;
    password: string;
}

export interface LoginResult {
    userId: string
    username: string
}
