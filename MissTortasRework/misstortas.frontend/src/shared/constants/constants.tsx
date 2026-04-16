/**
 * Shared frontend constants
 *
 * Keep configuration values, route helpers, keys and small enums here.
 * Do not include sensitive secrets.
 */

export const LOCAL_STORAGE_KEYS = {
  AUTH_TOKEN: 'authToken', // access token stored under this key per project guidelines
  USER: 'user',
  CART: 'cart',
} as const;

export const COOKIES = {
    USERNAME:"X-Username",
    ACCESS_TOKEN:"X-Access-Token"
}

export const API = {
  // Prefer overriding via environment variables in different environments
  ENDPOINTS: {
    AUTH_LOGIN: '/auth/login',
    AUTH_REGISTER: '/auth/register',
    AUTH_REFRESH: '/auth/refresh',
    PRODUCTS: '/products',
    PRODUCT_BY_ID: (id: string) => `/products/${id}`,
    ORDERS: '/orders',
    ORDER_BY_ID: (id: string) => `/orders/${id}`,
    CATEGORIES: '/categories',
    UPLOAD: '/upload',
  },
} as const;

export const ROUTES = {
  HOME: '/',
  ABOUT: '/about',
  LOGIN: '/login',
  REGISTER: '/register',
  PROFILE: '/profile',
  PRODUCTS: '/products',
  PRODUCT: (id: string) => `/products/${id}`,
  CART: '/cart',
  CHECKOUT: '/checkout',
  ORDERS: '/orders',
  ORDER: (id: string) => `/orders/${id}`,
  ADMIN: '/admin',
} as const;

export enum UserRole {
  Guest = 'guest',
  Customer = 'customer',
  Admin = 'admin',
}

export const ORDER_STATUSES = {
  PENDING: 'pending',
  CONFIRMED: 'confirmed',
  PREPARING: 'preparing',
  READY: 'ready',
  DELIVERED: 'delivered',
  CANCELLED: 'cancelled',
} as const;
export type OrderStatus = (typeof ORDER_STATUSES)[keyof typeof ORDER_STATUSES];

export const PAYMENT_METHODS = {
  CASH: 'cash',
  CARD: 'card',
  ONLINE: 'online',
} as const;

export const PAGINATION = {
  DEFAULT_PAGE: 1,
  DEFAULT_PAGE_SIZE: 10,
  PAGE_SIZE_OPTIONS: [10, 20, 50],
} as const;

export const DATE_FORMATS = {
  ISO_DATE: 'YYYY-MM-DD',
  DISPLAY_DATE: 'DD/MM/YYYY',
  DISPLAY_DATETIME: 'DD/MM/YYYY HH:mm',
  TIME: 'HH:mm',
} as const;

export const VALIDATION = {
  EMAIL_REGEX: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
  PASSWORD_MIN_LENGTH: 8,
  NAME_MAX_LENGTH: 100,
  PHONE_REGEX: /^\+?[0-9\s\-()]{7,20}$/,
} as const;

export const UI = {
  DEFAULT_IMAGE: '/assets/images/placeholder.png',
  MAX_IMAGE_UPLOAD_MB: 5,
  SUPPORTED_IMAGE_TYPES: ['image/png', 'image/jpeg', 'image/webp'],
} as const;

export const TAILWIND_BREAKPOINTS = {
  SM: 640,
  MD: 768,
  LG: 1024,
  XL: 1280,
} as const;

// Helper types exported for convenience
export type ApiEndpoints = typeof API.ENDPOINTS;
export type Routes = typeof ROUTES;
export type LocalStorageKeys = typeof LOCAL_STORAGE_KEYS;