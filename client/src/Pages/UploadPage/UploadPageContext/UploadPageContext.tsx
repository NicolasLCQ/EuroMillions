import {createContext, useState} from "react";

export interface UploadPageContextType {
	files: File[],
	addFiles: (file: File[]) => void;
	removeFile: (file: File) => void;
	clearFiles: () => void;
}

const UploadPageContext = createContext<UploadPageContextType>({
	files: [],
	addFiles: () => {
	},
	removeFile: () => {
	},
	clearFiles: () => {
	},
});

export const UploadPageContextProvider = ({children}) => {
	const [files, setFiles] = useState([]);

	const addFiles = (newFiles) => {
		console.log('before add :\n' + JSON.stringify(files));
		setFiles([
			...files,
			...newFiles
		]);
		console.log('after add :\n' + JSON.stringify(files));
	}

	const removeFile = (file: File) => {
		console.log('before delete :\n' + JSON.stringify(files));
		setFiles(files.map(f => {
			if (f != file) {
				return file;
			}
		}));
		console.log('after delete:\n' + JSON.stringify(files));
	}

	const clearFiles = () => {
		console.log('before clear :\n' + JSON.stringify(files));
		setFiles([]);
		console.log('after clear :\n' + JSON.stringify(files));
	}

	return (
		<UploadPageContext.Provider value={{files, addFiles, removeFile, clearFiles}}>
			{children}
		</UploadPageContext.Provider>
	);
}

export default UploadPageContext;



