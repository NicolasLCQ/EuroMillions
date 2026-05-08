import {BaseDropZoneComponent} from "shared/components/DropZoneComponents";
import {useFiles} from "shared/hooks";
import {ButtonComponents} from "shared/components/ButtonComponents";

export interface DropZoneComponentProps {
	className?: string;
	handleSubmitFiles: (files: File[]) => Promise<void>;
}

function DropZoneComponent(props: DropZoneComponentProps) {
	const {files, addFiles, removeFile, clearFiles} = useFiles();

	const handleClick = async () => {
		await props.handleSubmitFiles(files);
		clearFiles();
	};

	return (
		// Add a shared element for errors, for example: you cannot add the same file twice.
		<div className={props.className}>
			<BaseDropZoneComponent files={files} handleAdd={addFiles}
			                       handleDelete={removeFile}/>
			<ButtonComponents onClick={handleClick}>Submit</ButtonComponents>
		</div>
	)
}

export default DropZoneComponent;


