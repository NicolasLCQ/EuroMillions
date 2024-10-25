import {useEnvVariables} from "../Hooks/EnvironmentVariablesHooks/EnvironmentVariablesHooks.tsx";

interface IUseEuroMillionsApiType{
		Get: <Type>(url: string) => Promise<Type | Error>,
		Post: (url: string, body: FormData) => Promise<Response | Error>
}

const useEuroMillionsApi: () => IUseEuroMillionsApiType = () => {
	const baseUrl = useEnvVariables().api.baseURL;

	const Get = async <Type>(url: string): Promise<Type | Error> => {

		const httpResponse = await fetch(`${baseUrl}${url}`,{
			method: 'GET'
		});

		if(httpResponse.ok){
			return await httpResponse.json();
		}

		return await httpResponse.json() as Error;
	}

	const Post = async (url: string, body: FormData): Promise<Response | Error> =>{
		const httpResponse =await fetch(`${baseUrl}${url}`, {
			method: 'POST',
			body: body,
		})

		if(httpResponse.ok) {
			return await httpResponse.json();
		}

		return await httpResponse.json() as Error;
	}

	return {
		Get,
		Post
	};
}

export default useEuroMillionsApi;