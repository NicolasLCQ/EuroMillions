import "./DropZoneComponents.css";
import {useDropzone} from "react-dropzone";
import {useCallback, useState} from "react";

interface DropZoneComponentsProps {
	classname?: string
}

export default function DropZoneComponents(props:DropZoneComponentsProps) {
	const [files, setFiles] = useState([]);

	const handleInput = useCallback(acceptedFiles => {
		console.log(acceptedFiles);
		setFiles([
			...files,
			...acceptedFiles.map(acceptedFile => {
				acceptedFile.preview = URL.createObjectURL(acceptedFile);
				return acceptedFile;
			})
		]);
	}, [files])

	const {getRootProps, getInputProps} = useDropzone(
		{
			accept:{
				"text/csv" : ['.csv']
			},
			onDrop: handleInput
		}
	);

	return (
		<>
			<div {...getRootProps({className: props.classname})}>
				<input {...getInputProps()}/>
				{files.length == 0 && <p className='DragInformation'>Drag 'n' drop some files here, or click to select files</p>}
				{files.length > 0 && files.map(file => <img className='Preview' src={file.preview} alt={file.name} onLoad={() => { URL.revokeObjectURL(file.preview) }}/>)}
			</div>
		</>
	)
}