import {NavLink} from "react-router-dom";
import "./NavBarElement.css";
import React from "react";

export interface INavBarComponentProps {
	text: string;
	link: string;
}

const NavBarElement: React.FC<INavBarComponentProps> = (props: INavBarComponentProps) => {
	return (
			<NavLink className="NavBarElement" to={props.link}>{props.text}</NavLink>
	);
}

export default NavBarElement;