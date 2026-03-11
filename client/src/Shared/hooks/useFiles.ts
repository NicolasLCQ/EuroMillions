import {useState} from "react";

export const useFiles = () => {
	const [files, setFiles] = useState<File[]>([]);

	const addFiles = (newFiles: File[]) => {
		setFiles((previousFiles) => [
			...previousFiles,
			...newFiles
		]);
	};

	const removeFile = (file: File) => {
		setFiles((previousFiles) => previousFiles.filter((f) => f !== file));
	};

	const clearFiles = () => {
		setFiles([]);
	};

	return {
		files,
		addFiles,
		removeFile,
		clearFiles,
	};
};
