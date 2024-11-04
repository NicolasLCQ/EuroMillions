import "./DropZoneComponents.css";
import {useDropzone} from "react-dropzone";
import FileComponent from "./FileComponents/FileComponent.tsx";
import React from "react";

interface DropZoneComponentsProps {
	classname?: string,
	files: File[]
	handleAdd: (files: File[]) => void,
	handleDelete: (file: File) => void,
}



const DropZoneComponent: React.FC<DropZoneComponentsProps> = ({classname, files, handleAdd, handleDelete}: DropZoneComponentsProps) => {
	function noDoubleValidator(file:File){
		if(files.map(f => f.name).includes(file.name)){
			return {
				code: "file-already-added",
				message: `${file}: already added`,
			}
		}
		return null;
	}

	const {getRootProps, getInputProps} = useDropzone(
		{
			accept: {
				"text/csv": ['.csv']
			},
			onDrop: (files) => handleAdd(files),
			validator: (file) => noDoubleValidator(file)

		}
	);

	const dragInformationsItem = <p className='DragInformation'>Drag 'n' drop some files here, or click to select files</p>;

	const fileListItem = <aside className="FileListSection">
		{files.map(file => <FileComponent className="FileComponent" file={file} handleDelete={handleDelete} key={file.name}/>)}
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

export default DropZoneComponent;