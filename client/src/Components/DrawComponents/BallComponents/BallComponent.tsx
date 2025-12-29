import React from "react";
import './BallComponent.css';

interface BallComponentProps {
	number: number;
	numberClassName?: string;
	classname?: string;
}

const BallComponent: React.FC<BallComponentProps> = (props: BallComponentProps) => {
	return (
		<div className={props.classname ?? "BallComponent"}>
			<span className={props.numberClassName ?? "NumberComponent"}>{props.number}</span>
		</div>
	)
}

export default BallComponent;