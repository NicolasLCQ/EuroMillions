import {NavLink} from "react-router-dom";
import styles from "./NavBarElement.module.css";
import React from "react";

export interface INavBarComponentProps {
	text: string;
	link: string;
}

const NavBarElement: React.FC<INavBarComponentProps> = (props: INavBarComponentProps) => {
	if (!props.link.trim()) {
		return <span className={`${styles.navBarElement} ${styles.disabled}`}>{props.text}</span>;
	}

	return (
			<NavLink className={({isActive}) => isActive ? `${styles.navBarElement} ${styles.active}` : styles.navBarElement} to={props.link}>{props.text}</NavLink>
	);
}

export default NavBarElement;
