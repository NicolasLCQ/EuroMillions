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

	const fileListItem = <aside className="FileListSection">
		{files
			.map(file =>
				<FileComponent className="FileComponent" file={file} handleDelete={handleDelete}
				               key={file.name}/>
			)
		}
	</aside>;

	return (
		<div className={classname ??"DropZoneComponent"}>
			<div {...getRootProps({className: "DropZoneSection"})}>
				<input {...getInputProps()}/>
				{dragInformationsItem}
			</div>
			{files?.length > 0 && fileListItem}

		</div>

	)
}