import './NavBarComponent.css';
import NavBarElement from "./NavBarElements/NavBarElement.tsx";
import React from "react";

interface INavBarComponentProps{
	textAndLinks?: {text: string; link: string}[];
}

const NavBarComponent: React.FC<INavBarComponentProps> = (props:INavBarComponentProps) => {
	return <div className="NavBar">
		{props.textAndLinks?.map((textAndLink, key) => <NavBarElement text={textAndLink.text} link={textAndLink.link} key={key} />)}
	</div>
}

export default NavBarComponent;