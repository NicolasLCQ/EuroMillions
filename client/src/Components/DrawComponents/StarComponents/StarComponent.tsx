import React from "react";
import './StarComponent.css';

interface StarComponentProps {
	number: number;
	numberClassName?: string;
	classname?: string;
}

const StarComponent: React.FC<StarComponentProps> = (props: StarComponentProps) => {
	return (
		<div className={props.classname ?? "StarComponent"}>
			<span className={props.numberClassName ?? "NumberComponent"}>{props.number}</span>
		</div>
	)
}

export default StarComponent;