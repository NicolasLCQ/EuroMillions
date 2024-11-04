import './DefaultButtonComponent.css';
import React, {ReactNode} from "react";

interface ButtonComponentsProps {
	classname?: string;
	children?: ReactNode;
	onClick: () => void;
}

const ButtonComponents : React.FC<ButtonComponentsProps> = (props: ButtonComponentsProps) => {

	return (
		<button className={props.classname??"ButtonComponents"} onClick={props.onClick}>{props.children}</button>
	)
}

export default ButtonComponents;