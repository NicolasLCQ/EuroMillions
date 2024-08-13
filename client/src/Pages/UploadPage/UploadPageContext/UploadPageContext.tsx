import {createContext, useState} from "react";

export interface UploadPageContextType {
	files: File[],
	addFiles: (file: File[]) => void;
	// removeFile: (file: File) => void;
	// clearFiles: () => void;
}

const UploadPageContext = createContext<UploadPageContextType>({
	files: [],
	addFiles: () => {
	},
	// removeFile: () => {
	// },
	// clearFiles: () => {
	// },
});

export const UploadPageConstextProvider = ({children}) => {
	const [files, setFiles] = useState([]);

	const addFiles = (newFiles) => {
		setFiles([
			...files,
			...newFiles
		])
	}

	return (
		<UploadPageContext.Provider value={{files, addFiles}}>
			{children}
		</UploadPageContext.Provider>
	);
}

export default UploadPageContext;



