import useEuroMillionsApi from "../../../../App/Api/EuroMillionsApiHooks.ts";

export const postFiles = async(files: File[]) => {
	const euroMillionsApi = useEuroMillionsApi();

	const body = new FormData();
	files.forEach(f => {body.append('file', f);});

	return await euroMillionsApi.Post("/upload/history_files", body)
}
