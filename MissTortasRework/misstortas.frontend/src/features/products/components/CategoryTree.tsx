import { useCategories } from '@/features/products/hooks/useCategories';
import CategoryTreeNode from '@/features/products/components/CategoryTreeNode';

export default function CategoryTree() {
    const { categories, loading, error } = useCategories();

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error loading categories</div>;
    if (!categories) return null;

    return (
        <div>
            {categories.map(category => (
                <CategoryTreeNode key={category.id} category={category} />
            ))}
        </div>
    );
}