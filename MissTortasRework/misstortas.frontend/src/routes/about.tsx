import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/about")({component: About})

function About() {
    return (
        <div>
            this is the about page
        </div>
    );
};