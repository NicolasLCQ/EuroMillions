import {euroMillionsAPI} from "../../../../api/api.ts";

export const postFiles = async(files: File[]) => {
	const body = new FormData();
	files.forEach(f => {body.append('file', f);});

	return await euroMillionsAPI.Post("/upload/history_files", body);
}
