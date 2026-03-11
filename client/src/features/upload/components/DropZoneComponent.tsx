import BaseDropZoneComponent from "shared/components/DropZoneComponents/DropZoneComponent.tsx";
import {useFiles} from "features/upload/hooks/useFiles.ts";
import ButtonComponents from "shared/components/ButtonComponents/DefaultButtonComponent.tsx";
import {postFiles} from "features/upload/api/postFiles.ts";
import {useMutation} from "@tanstack/react-query";

export interface DropZoneComponentProps {
	className?: string
}

function DropZoneComponent(props: DropZoneComponentProps) {
	const {files, addFiles, removeFile, clearFiles} = useFiles();

	const fileMutation = useMutation({
		mutationFn: (f: File[]) => postFiles(f),
		onSuccess: clearFiles,
		onError: e => console.log(e)
	});

	const handleClick = () => fileMutation.mutate(files);

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


