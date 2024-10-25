/// <reference types="vite/client" />

interface ImportMetaEnv {
	readonly VITE_API_URL: string
	// more env variables with matching name...
}

interface ImportMeta {
	readonly env: ImportMetaEnv
}