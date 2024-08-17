import "./DropZoneComponents.css";
import {useDropzone} from "react-dropzone";
import FileComponent from "./FileComponents/FileComponent.tsx";

interface DropZoneComponentsProps {
	classname?: string,
	files: File[]
	handleAdd: (files: File[]) => void,

}

export default function DropZoneComponent({classname, files, handleAdd}: DropZoneComponentsProps) {

	const {getRootProps, getInputProps} = useDropzone(
		{
			accept: {
				"text/csv": ['.csv']
			},
			onDrop: handleAdd,
		}
	);

	return (
		<>
			<div {...getRootProps({className: classname ?? "DropZone"})}>
				<input {...getInputProps()}/>
				{files.length == 0 &&
					<p className='DragInformation'>Drag 'n' drop some files here, or click to select files</p>}
				{files.length > 0 && files.map(file =>
					<FileComponent className="FileComponent" file={file} key={file.name}/>
				)}
			</div>
		</>
	)
}