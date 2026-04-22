import apiClient from "@/shared/api/apiClient";
import endpoints from "@/features/products/api/endpoints";
import { CreateCategory } from "@/features/products/categoryTypes";

export async function allCategories() {
    const response = await apiClient.get(endpoints.categories.all);
    return response.data;
}
export async function createCategory(payload: CreateCategory) {
    const response = await apiClient.post(endpoints.categories.create, payload);
    return response.data;
}
export async function deleteCategory(id: string) {
    const response = await apiClient.delete(endpoints.categories.delete(id));
    return response.data;
}