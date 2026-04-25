// Types for authentication feature

export enum AuthStatus {
  Idle = 'idle',
  Loading = 'loading',
  Authenticated = 'authenticated',
  Unauthenticated = 'unauthenticated',
  Error = 'error',
}

export interface User {
  id: string;
  email: string;
  name?: string;
  role?: string;
  avatarUrl?: string;
  createdAt?: string;
  // add additional server/user fields as needed
}

export interface Tokens {
  accessToken: string;
  refreshToken?: string;
  expiresIn?: number; // seconds
  tokenType?: string;
}

export interface AuthState {
  user: User | null;
  tokens: Tokens | null;
  status: AuthStatus;
  error?: string | null;
  // whether the user chose "remember me" (optional)
  remember?: boolean;
}

export type LoginCredentials = {
  email: string;
  password: string;
  remember?: boolean;
};

export type LoginResult = {
};

export type RegisterData = {
  name?: string;
  email: string;
  password: string;
  confirmPassword?: string;
};

export type AuthResponse = {
  user: User;
  tokens: Tokens;
};

export type RefreshPayload = {
  refreshToken: string;
};

export enum AuthActionType {
  LoginRequest = 'auth/LOGIN_REQUEST',
  LoginSuccess = 'auth/LOGIN_SUCCESS',
  LoginFailure = 'auth/LOGIN_FAILURE',

  RegisterRequest = 'auth/REGISTER_REQUEST',
  RegisterSuccess = 'auth/REGISTER_SUCCESS',
  RegisterFailure = 'auth/REGISTER_FAILURE',

  Logout = 'auth/LOGOUT',
  SetUser = 'auth/SET_USER',

  RefreshRequest = 'auth/REFRESH_REQUEST',
  RefreshSuccess = 'auth/REFRESH_SUCCESS',
  RefreshFailure = 'auth/REFRESH_FAILURE',
}

export type AuthAction =
  | { type: AuthActionType.LoginRequest; payload: LoginCredentials }
  | { type: AuthActionType.LoginSuccess; payload: AuthResponse }
  | { type: AuthActionType.LoginFailure; error: string }
  | { type: AuthActionType.RegisterRequest; payload: RegisterData }
  | { type: AuthActionType.RegisterSuccess; payload: AuthResponse }
  | { type: AuthActionType.RegisterFailure; error: string }
  | { type: AuthActionType.Logout }
  | { type: AuthActionType.SetUser; payload: User | null }
  | { type: AuthActionType.RefreshRequest; payload: RefreshPayload }
  | { type: AuthActionType.RefreshSuccess; payload: Tokens }
  | { type: AuthActionType.RefreshFailure; error: string };