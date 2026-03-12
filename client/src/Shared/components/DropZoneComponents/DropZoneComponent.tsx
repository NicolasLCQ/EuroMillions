import styles from "./DropZoneComponent.module.css";
import {useDropzone} from "react-dropzone";
import FileComponent from "./FileComponents";
import React from "react";

interface DropZoneComponentsProps {
	className?: string,
	files: File[]
	handleAdd: (files: File[]) => void,
	handleDelete: (file: File) => void,
}



const DropZoneComponent: React.FC<DropZoneComponentsProps> = ({className, files, handleAdd, handleDelete}: DropZoneComponentsProps) => {
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

	const dragInformationsItem = <p className={styles.dragInformation}>Drag 'n' drop some files here, or click to select files</p>;

	const fileListItem = <aside className={styles.fileListSection}>
		{files.map(file => <FileComponent file={file} handleDelete={handleDelete} key={file.name}/>)}
	</aside>;

	return (
		<div className={className ? `${styles.dropZone} ${className}` : styles.dropZone}>
			<div {...getRootProps({className: styles.dropZoneSection})}>
				<input {...getInputProps()}/>
				{dragInformationsItem}
			</div>
			{files?.length > 0 && fileListItem}

		</div>

	)
}

export default DropZoneComponent;

