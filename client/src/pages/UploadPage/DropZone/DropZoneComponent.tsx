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
		//ajouter un element general pour afficher des erreurs comme : vous ne pouvez pas entrer 2 fois le meme fichier
		<div className={props.className}>
			<BaseDropZoneComponent files={files} handleAdd={addFiles}
			                       handleDelete={removeFile}/>
			<ButtonComponents onClick={handleClick}>Submit</ButtonComponents>
		</div>
	)
}

export default DropZoneComponent;



