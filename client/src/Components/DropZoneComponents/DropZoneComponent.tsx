import "./DropZoneComponents.css";
import {useDropzone} from "react-dropzone";
import FileComponent from "./FileComponents/FileComponent.tsx";

interface DropZoneComponentsProps {
	classname?: string,
	files: File[]
	handleAdd: (files: File[]) => void,
	handleDelete: (file: File) => void,
}

export default function DropZoneComponent({classname, files, handleAdd, handleDelete}: DropZoneComponentsProps) {

	const {getRootProps, getInputProps} = useDropzone(
		{
			accept: {
				"text/csv": ['.csv']
			},
			onDrop: handleAdd,

		}
	);

	const dragInformationsItem = <p className='DragInformation'>Drag 'n' drop some files here, or click to select
		files</p>;

	const fileListItem = <div className="FileList">
		{files
			.map(file =>
				<FileComponent className="FileComponent" file={file} handleDelete={handleDelete}
				               key={file?.name}/>
			)
		}
	</div>;

	return (
		<>
			<div {...getRootProps({className: classname ?? "DropZone"})}>
				<input {...getInputProps()}/>
				{files.length === 0 && dragInformationsItem}
			</div>
			<div>
				{files.length > 0 && fileListItem}
			</div>
		</>

	)
}