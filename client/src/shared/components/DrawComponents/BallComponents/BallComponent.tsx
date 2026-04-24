import React from "react";
import styles from './BallComponent.module.css';

export interface BallComponentProps {
	number: number;
	numberClassName?: string;
	className?: string;
}

const BallComponent: React.FC<BallComponentProps> = (props: BallComponentProps) => {
	const ballClassName = props.className ? `${styles.ball} ${props.className}` : styles.ball;
	const numberClassName = props.numberClassName ? `${styles.number} ${props.numberClassName}` : styles.number;

	return (
		<div className={ballClassName}>
			<span className={numberClassName}>{props.number}</span>
		</div>
	)
}

export default BallComponent;
