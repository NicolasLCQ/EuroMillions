import {NavLink} from "react-router-dom";

export interface INavBarComponentProps {
	text: string;
	link: string;
}

export default function NavBarElement(props: INavBarComponentProps) {
	return (
			<NavLink to={props.link}>{props.text}</NavLink>
	);
}