import React from "react";
import './DrawComponent.css';
import BallComponent from '../DrawComponents/BallComponents/BallComponent.tsx';
import StarComponent from '../DrawComponents/StarComponents/StarComponent.tsx';
import {IDraw} from '../../Models/DrawModels/IDraw.ts';

interface DrawComponentsProps {
	Draw: IDraw
	classname?: string;
}

const DrawComponent: React.FC<DrawComponentsProps> = (props: DrawComponentsProps) => {

	return (
		<div className={props.classname ?? "DrawComponent"}>
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