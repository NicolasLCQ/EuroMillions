import API_ROUTES from "./client/routes.ts";

export const postFiles = async(files: File[]) => {

	const body = new FormData();
	files.forEach(f => {body.append('file', f);});

	const httpResponse =await fetch(API_ROUTES.uploadFiles, {
		method: 'POST',
		body: body,
	})

	if(!httpResponse.ok) {
		throw new Error(`PostFiles failed with status ${httpResponse.status}`);
	}

	return await httpResponse.json() as Response;
}
