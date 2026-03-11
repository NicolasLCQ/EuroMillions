import styles from './DefaultButtonComponent.module.css';
import React, {ReactNode} from "react";

interface ButtonComponentsProps {
	className?: string;
	children?: ReactNode;
	onClick: () => void;
}

const ButtonComponents : React.FC<ButtonComponentsProps> = (props: ButtonComponentsProps) => {
	const className = props.className ? `${styles.button} ${props.className}` : styles.button;

	return (
		<button className={className} onClick={props.onClick}>{props.children}</button>
	)
}

export default ButtonComponents;
