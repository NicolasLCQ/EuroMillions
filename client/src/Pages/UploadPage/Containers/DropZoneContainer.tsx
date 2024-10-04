import DropZoneComponent from "../../../Components/DropZoneComponents/DropZoneComponent.tsx";
import {useFiles} from "../Hooks/useFiles.ts";
import ButtonComponents from "../../../Components/ButtonComponents/DefaultButtonComponent.tsx";
import {postFiles} from "../Features/Files/PostFiles.ts";
import {useMutation} from "@tanstack/react-query";

export interface DropZoneContainerProps {
	className?: string
}

export default function DropZoneContainer(props: DropZoneContainerProps) {
	const {files, addFiles, removeFile, clearFiles} = useFiles();

	const fileMutation = useMutation({
		mutationFn: (f: File[]) => postFiles(f),
		onSuccess: clearFiles,
	});

	return (
		//ajouter un element general pour afficher des erreurs comme : vous ne pouvez pas entrer 2 fois le meme fichier
		<div className={props.className ?? "DropZoneContainer"}>
			<DropZoneComponent classname="DropZoneComponent" files={files} handleAdd={addFiles}
			                   handleDelete={removeFile}/>
			<ButtonComponents onClick={() => fileMutation.mutate(files)}>Submit</ButtonComponents>
		</div>
	)
}