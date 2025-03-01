/*
const baseUrl = import.meta.env.VITE_API_URL;

export interface IEuroMillionsAPI {
	Get: <Type>(url: string) => Promise<Type | Error>,
	Post: (url: string, body: FormData) => Promise<Response | Error>
}
//TODO : get rid of heritage
class EuroMillionsAPI implements IEuroMillionsAPI{

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
*/
