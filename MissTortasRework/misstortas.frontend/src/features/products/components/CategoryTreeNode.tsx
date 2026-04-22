import { useState } from 'react';
import { Category } from '@/features/products/categoryTypes';
import {
    useDeleteCategory,
    useCreateCategory,
} from '@/features/products/hooks/useCategories';

interface Props {
    category: Category;
    level?: number;
}

export default function CategoryTreeNode({ category, level = 0 }: Props) {
    const [expanded, setExpanded] = useState(true);
    const { remove } = useDeleteCategory();
    const { create } = useCreateCategory();

    const hasChildren = category.children && category.children.length > 0;

    function handleAdd() {
        const name = prompt('New category name');
        if (!name) return;

        create({
            name,
            parentId: category.id,
        });
    }

    function handleDelete() {
        if (!confirm(`Delete ${category.name}?`)) return;
        remove(category.id);
    }

    return (
        <div>
            <div
                style={{
                    display: 'flex',
                    alignItems: 'center',
                    padding: '4px 0',
                    paddingLeft: `${level * 12}px`,
                    gap: '6px',
                    cursor: 'pointer',
                }}
            >
                {/* Expand / collapse */}
                <span onClick={() => setExpanded(prev => !prev)}>
                    {hasChildren ? (expanded ? '▼' : '▶') : '•'}
                </span>

                {/* Name */}
                <span style={{ flex: 1 }}>{category.name}</span>

                {/* Actions ONLY if final */}
                {category.isFinal && (
                    <>
                        <button onClick={handleAdd}>＋</button>
                        <button onClick={handleDelete}>🗑</button>
                    </>
                )}
            </div>

            {/* Children */}
            {expanded &&
                hasChildren &&
                category.children!.map(child => (
                    <CategoryTreeNode
                        key={child.id}
                        category={child}
                        level={level + 1}
                    />
                ))}
        </div>
    );
}