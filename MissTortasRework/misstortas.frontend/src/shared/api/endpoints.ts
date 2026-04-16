export const endpoints = {
    auth: {
        login: "/auth/signin",
        register: "/auth/signup",
    },
    users: {
        getAll: "/users",
        getById: (id: string) => `/users/${id}`,
    },
    products: {
        list: "/products",
        details: (id: string) => `/products/${id}`,
    },
};
export default endpoints;