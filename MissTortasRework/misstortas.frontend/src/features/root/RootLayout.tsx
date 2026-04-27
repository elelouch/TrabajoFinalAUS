import { Link, Outlet } from "@tanstack/react-router";

export function RootLayout() {
    return (
        <div>

            < nav className="flex items-center justify-between px-8 py-4 bg-gray-100 border-b" >
                <h1 className="text-xl font-semibold" > My App </h1>

                < div className="flex space-x-4" >
                    <Link to="/signin" className="text-blue-600 hover:underline" >
                        Sign In
                    </Link>
                    < Link to="/signup" className="text-blue-600 hover:underline" >
                        Sign Up
                    </Link>
                    < Link to="/products" className="text-blue-600 hover:underline" >
                        Products
                    </Link>
                    < Link to="/users" className="text-blue-600 hover:underline" >
                        Users
                    </Link>
                </div>
            </nav>

            {/* Page content */}
            <div className="p-8" >
                <Outlet />
            </div>
        </div>
    )
}