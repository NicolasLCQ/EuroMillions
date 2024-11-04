import {useEnvVariables} from "App/Hooks/EnvironmentVariablesHooks/EnvironmentVariablesHooks.tsx";

const ApiPostFunction = async (url: string, body: FormData): Promise<Response | Error> =>{
	const baseUrl = useEnvVariables().api.baseURL;

	const httpResponse =await fetch(`${baseUrl}${url}`, {
		method: 'POST',
		body: body,
	})

	if(httpResponse.ok) {
		return await httpResponse.json() as Response;
	}

	return await httpResponse.json() as Error;
}

export default ApiPostFunction;