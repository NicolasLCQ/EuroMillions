import {ReactNode} from "react";
import styles from "./TextComponent.module.css";

interface ITextComponentProps {
	className?: string;
	children?: ReactNode | string;
}

export default function TextComponent(props: ITextComponentProps) {
	const className = props.className
		?`${styles.text} ${props.className}`
		: styles.text;

	return (
		<div className={className}>{props.children}</div>
	)
}
