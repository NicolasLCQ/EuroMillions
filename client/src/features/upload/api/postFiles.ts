import {config} from "app/config";

export const postFiles = async(files: File[]) => {
	const baseUrl = config.API_URL

	const body = new FormData();
	files.forEach(f => {body.append('file', f);});

	const httpResponse =await fetch(`${baseUrl}/upload/history_files`, {
		method: 'POST',
		body: body,
	})

	if(!httpResponse.ok) {
		throw new Error(`PostFiles failed with status ${httpResponse.status}`);
	}

	return await httpResponse.json() as Response;
}
