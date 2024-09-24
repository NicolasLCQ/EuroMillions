const baseUrl = "https://localhost:3001";//process.env.API_URL;

class EuroMillionsAPI {

	public async Get<Type>(url: string): Promise<Type | Error> {
		return fetch(`${baseUrl}${url}`, {
			method: 'GET',
		}).then((response: Response) => {
			return response.json();
		}).catch((error: Error) => {
			return error;
		});
	}

	public async Post(url: string, body:FormData): Promise<Response | Error> {
		return fetch(`${baseUrl}${url}`, {
			method: 'POST',
			body: body,
		}).then((response: Response) => {
			return response.json();
		}).catch((error: Error) => {
			return error;
		});
	}
}

export const euroMillionsAPI:EuroMillionsAPI = new EuroMillionsAPI();

//euroMillionsAPI.Post<File[]>(files)