import "./FileComponent.css";
import DeleteButtonGlyphIconComponent
	from "../../ButtonComponents/DeleteButtonComponent/DeleteButtonGlyphIconComponent.tsx";
import TextComponent from "../../TextComponents/TextComponent/TextComponent.tsx";

export interface FileComponentProps {
	className?: string,
	file: File,
	handleDelete?: (file: File) => void,
}

export default function FileComponent(props: FileComponentProps) {
	const handleDelete = () => () => props.handleDelete(props.file);

	return (
		<div className={props.className ?? "FileComponent"}>
			{props.handleDelete &&
				<>
					<DeleteButtonGlyphIconComponent className="DeleteFileButton"
					                                handleDelete={handleDelete}/>
					&nbsp;
				</>
			}
			<TextComponent className="FileName">{props.file.name}</TextComponent>
		</div>
	)
}