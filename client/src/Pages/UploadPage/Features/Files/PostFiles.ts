import {euroMillionsAPI} from "../../../../api/api.ts";

export const postFiles = (files: File[]) => {
	const body = new FormData();
	files.forEach(f => {body.append('file', f);});

	euroMillionsAPI.Post("/upload/postFiles", body);
}
