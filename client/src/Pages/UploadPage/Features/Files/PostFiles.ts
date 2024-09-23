import {euroMillionsAPI} from "../../../../api/api.ts";

export const postFiles = (files: File[]) => {
	euroMillionsAPI.Post<File[]>("/upload/files", files)
}
