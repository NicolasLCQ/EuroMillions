import React from "react";
import styles from './StarComponent.module.css';

export interface StarComponentProps {
	number: number;
	numberClassName?: string;
	className?: string;
}

const StarComponent: React.FC<StarComponentProps> = (props: StarComponentProps) => {
	const starClassName = props.className ? `${styles.star} ${props.className}` : styles.star;
	const numberClassName = props.numberClassName ? `${styles.number} ${props.numberClassName}` : styles.number;

	return (
		<div className={starClassName}>
			<span className={numberClassName}>{props.number}</span>
		</div>
	)
}

export default StarComponent;
