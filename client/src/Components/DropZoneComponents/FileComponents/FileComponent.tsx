import styles from "./FileComponent.module.css";
import DeleteButtonGlyphIconComponent
	from "../../ButtonComponents/DeleteButtonComponents/DeleteButtonGlyphIconComponent.tsx";
import TextComponent from "../../TextComponents/TextComponent/TextComponent.tsx";

export interface FileComponentProps {
	className?: string,
	file: File,
	handleDelete?: (file: File) => void,
}

export default function FileComponent(props: FileComponentProps) {
	const handleDelete = () => props.handleDelete?.(props.file);
	const containerClassName = props.className ? `${styles.file} ${props.className}` : styles.file;

	return (
		<div className={containerClassName}>
			{props.handleDelete &&
				<>
					<DeleteButtonGlyphIconComponent className={styles.deleteButton}
					                                handleDelete={handleDelete}/>
					&nbsp;
				</>
			}
			<TextComponent className={styles.fileName}>{props.file.name}</TextComponent>
		</div>
	)
}
