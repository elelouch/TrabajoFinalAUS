import CategoryTree from '@/features/products/components/CategoryTree';

export default function CategoryLayout() {
    return (
        <div style={{ display: 'flex', height: '100%' }}>
            <aside
                style={{
                    width: '30%',
                    borderRight: '1px solid #ddd',
                    overflowY: 'auto',
                    padding: '8px',
                }}
            >
                <CategoryTree />
            </aside>

            <main style={{ flex: 1, padding: '16px' }}>
                {/* whatever content depends on selected category */}
            </main>
        </div>
    );
}