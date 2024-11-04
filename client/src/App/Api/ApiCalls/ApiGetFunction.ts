import {useEnvVariables} from "App/Hooks/EnvironmentVariablesHooks/EnvironmentVariablesHooks.tsx";

const ApiGetFunction = async <Type>(url: string): Promise<Type | Error> => {
	const baseUrl = useEnvVariables().api.baseURL;

	const httpResponse = await fetch(`${baseUrl}${url}`,{
		method: 'GET'
	});

	if(httpResponse.ok){
		return await httpResponse.json() as Type;
	}

	return await httpResponse.json() as Error;
}

export default ApiGetFunction;