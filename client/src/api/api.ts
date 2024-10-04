const baseUrl = "https://localhost:3001";//process.env.API_URL;

class EuroMillionsAPI {

	public async Get<Type>(url: string): Promise<Type | Error> {
		return (
			await fetch(`${baseUrl}${url}`, {
				method: 'GET',
			})
		).json();
	}

	public async Post(url: string, body: FormData): Promise<Response | Error> {
		return (
			await fetch(`${baseUrl}${url}`, {
				method: 'POST',
				body: body,
			})
		).json();
	}
}

export const euroMillionsAPI: EuroMillionsAPI = new EuroMillionsAPI();