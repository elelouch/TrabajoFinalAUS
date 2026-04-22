export const endpoints = {
    products: {
        list: "/products",
        details: (id: string) => `/products/${id}`,
    },
    categories: {
        all: "/productscategories",
        create: "/productscategories", // POST: Create a new category
        delete: (id: string) => `/productscategories/${id}`, // DELETE: Delete a category by ID
    }
     ,
};
export default endpoints;