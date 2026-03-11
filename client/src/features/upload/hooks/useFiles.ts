import {useState} from "react";

export const useFiles = () => {
	const [files, setFiles] = useState<File[]>([]);

	const addFiles = (newFiles) => {
		setFiles([
			...files,
			...newFiles
		]);
	}

	const removeFile = (file: File) => {
		setFiles(files.filter(f => f !== file));
	}

	const clearFiles = () => {
		setFiles([]);
	}

	return {
		files,
		addFiles,
		removeFile,
		clearFiles,
	}
}