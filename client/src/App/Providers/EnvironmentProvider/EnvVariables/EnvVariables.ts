interface IApiType {
	baseURL: string;
}

export interface IEnvVariablesType {
	env: string,
	api: IApiType
}

const ENV = import.meta.env;
export const mappedEnvVariables: IEnvVariablesType = {
	env: ENV.MODE,
	api: {
		baseURL: ENV.VITE_API_URL
	}
}