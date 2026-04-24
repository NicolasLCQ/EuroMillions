import styles from './NavBarComponent.module.css';
import { NavBarElement } from "./NavBarElements";
import React from "react";

interface INavBarComponentProps{
	textAndLinks?: {text: string; link: string}[];
}

const NavBarComponent: React.FC<INavBarComponentProps> = (props:INavBarComponentProps) => {
	return <div className={styles.navBar}>
		{props.textAndLinks?.map((textAndLink, key) => <NavBarElement text={textAndLink.text} link={textAndLink.link} key={key} />)}
	</div>
}

export default NavBarComponent;

