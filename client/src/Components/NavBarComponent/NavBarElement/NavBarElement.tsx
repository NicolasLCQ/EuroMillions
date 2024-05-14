import {NavLink} from "react-router-dom";
import "./NavBarElement.css";

export interface INavBarComponentProps {
	text: string;
	link: string;
}

export default function NavBarElement(props: INavBarComponentProps) {
	return (
			<NavLink className="NavBarElement" to={props.link}>{props.text}</NavLink>
	);
}