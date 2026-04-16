import axios from 'axios';
import type { AxiosInstance } from 'axios';

const apiClient: AxiosInstance = axios.create({
    baseURL: "/api",
    headers: {
        'Content-Type': 'application/json',
    },
    withCredentials: true
});

apiClient.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('authToken');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => Promise.reject(error)
);

apiClient.interceptors.response.use(
    (response) => response,
    (error) => {
        if (error.response?.status === 401) {
            // Handle unauthorized access, e.g., redirect to login
            console.error('Unauthorized access - redirecting to login');
        }
        return Promise.reject(error);
    }
);

export default apiClient;