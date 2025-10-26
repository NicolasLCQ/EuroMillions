import {config} from "../../../../Config";

export const postFiles = async(files: File[]) => {
	const baseUrl = config.API_URL

	const body = new FormData();
	files.forEach(f => {body.append('file', f);});

	const httpResponse =await fetch(`${baseUrl}/upload/history_files`, {
		method: 'POST',
		body: body,
	})

	if(httpResponse.ok) {
		return await httpResponse.json() as Response;
	}

	return await httpResponse.json() as Error;
}
