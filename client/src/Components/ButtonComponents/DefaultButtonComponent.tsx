import './DefaultButtonComponent.css';
import {ReactNode} from "react";

interface ButtonComponentsProps {
	classname?: string;
	children?: ReactNode;
	onClick: () => void;
}

export default function ButtonComponents(props: ButtonComponentsProps) {

	return (
		<button className={props.classname??"ButtonComponents"} onClick={props.onClick}>{props.children}</button>
	)
}