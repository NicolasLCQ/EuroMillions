interface IApiType {
	baseURL: string;
}

export interface IEnvVariablesType {
	env: string,
	api: IApiType
}