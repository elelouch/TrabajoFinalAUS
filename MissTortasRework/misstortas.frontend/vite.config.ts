import { defineConfig } from 'vite'
import { devtools } from '@tanstack/devtools-vite'
import { tanstackStart } from '@tanstack/react-start/plugin/vite'

import viteReact from '@vitejs/plugin-react'
import tailwindcss from '@tailwindcss/vite'

const firstApi = "https://localhost:7245"

const config = defineConfig({
    server:{
        proxy:{
            '^/api': {
                target: firstApi,
                changeOrigin: true,
                secure: false,
                rewrite: (path) => path.replace(/^\/api/, ''),
            },
        }
    },  
    resolve: { tsconfigPaths: true },
    plugins: [
        devtools(),
        tailwindcss(),
        tanstackStart(),
        viteReact({
            babel: {
                plugins: ['babel-plugin-react-compiler'],
            },
        }),
    ],
})

export default config
