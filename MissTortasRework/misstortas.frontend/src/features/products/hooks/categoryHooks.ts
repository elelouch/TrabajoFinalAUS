/* Category hooks for fetching and mutating categories.
   - Prefers `apiClient` service if available; falls back to fetch.
*/

import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import { allCategories, createCategory, deleteCategory } from '@/features/products/api/categoryApi';

const CATEGORY_QUERY_KEY = ['categories'];

export function useCategories() {
    const { data: categories, isLoading: loading, error } = useQuery(CATEGORY_QUERY_KEY, allCategories);

    return {
        categories,
        loading,
        error,
    };
}

// Hook for creating a category
export function useCreateCategory() {
    const queryClient = useQueryClient();

    const mutation = useMutation(createCategory, {
        onSuccess: () => {
            queryClient.invalidateQueries(CATEGORY_QUERY_KEY);
        },
    });

    return {
        create: mutation.mutate,
        loading: mutation.isLoading,
        error: mutation.error,
    };
}

// Hook for deleting a category
export function useDeleteCategory() {
    const queryClient = useQueryClient();

    const mutation = useMutation(deleteCategory, {
        onSuccess: () => {
            queryClient.invalidateQueries(CATEGORY_QUERY_KEY);
        },
    });

    return {
        remove: mutation.mutate,
        loading: mutation.isLoading,
        error: mutation.error,
    };
}