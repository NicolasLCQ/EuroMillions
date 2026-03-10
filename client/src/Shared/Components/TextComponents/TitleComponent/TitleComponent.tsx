import {ReactNode} from "react";
import styles from "./TitleComponent.module.css";

interface ITitleComponentProps {
	className?: string;
	children?: ReactNode | string;
}

function TitleComponent(props: ITitleComponentProps) {
	const className = props.className ? `${styles.title} ${props.className}` : styles.title;

	return (
		<div className={className}>{props.children}</div>
	)
}

export default TitleComponent;
