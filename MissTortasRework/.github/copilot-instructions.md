# Copilot Instructions

## Project Guidelines
- Use Tailwind CSS for component styling; avoid importing local CSS files. Prefer functional/declarative React style.
- When updating auth components, encapsulate API calls in services (authService) using apiClient for HTTP requests; avoid hardcoded endpoints in components. Store the access token in localStorage under the 'authToken' key.