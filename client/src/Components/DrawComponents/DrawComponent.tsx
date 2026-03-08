import React from "react";
import styles from './DrawComponent.module.css';
import BallComponent from '../DrawComponents/BallComponents/BallComponent.tsx';
import StarComponent from '../DrawComponents/StarComponents/StarComponent.tsx';
import {IDraw} from 'Models/DrawModels/IDraw.ts';

interface DrawComponentsProps {
	Draw: IDraw
	className?: string;
}

const DrawComponent: React.FC<DrawComponentsProps> = (props: DrawComponentsProps) => {
	const className = props.className ? `${styles.draw} ${props.className}` : styles.draw;

	return (
		<div className={className}>
			<BallComponent number={props.Draw.ball1}/>
			<BallComponent number={props.Draw.ball2}/>
			<BallComponent number={props.Draw.ball3}/>
			<BallComponent number={props.Draw.ball4}/>
			<BallComponent number={props.Draw.ball5}/>
			<StarComponent number={props.Draw.star1}/>
			<StarComponent number={props.Draw.star2}/>
		</div>
	)
}

export default DrawComponent;
