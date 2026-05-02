import { Link } from "@tanstack/react-router";

export function UsersLink() {
    return (
        < Link to="/users" className="text-blue-600 hover:underline" >
            Users
        </Link>
    )
}