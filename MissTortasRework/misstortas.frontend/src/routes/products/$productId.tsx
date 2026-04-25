import { createFileRoute } from "@tanstack/react-router"

export const Route = createFileRoute('/products/$productId')({
    component: RouteComponent,
    loader: async ({ params }) => {
        await new Promise((res, rej) => setTimeout(res, 1000));
        return {
            productId: params.productId
        }
    },
    pendingComponent: () => (<div>Loading...</div>)
})



function RouteComponent() {
    const { productId } = Route.useLoaderData();
    return (<div>Hello from {productId} </div>)
}