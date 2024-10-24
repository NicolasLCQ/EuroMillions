import './NavBarComponent.css';
import NavBarElement from "./NavBarElements/NavBarElement.tsx";

interface INavBarComponentProps{
	textAndLinks?: {text: string; link: string}[];
}

export default function NavBarComponent(props:INavBarComponentProps) {
	return <div className="NavBar">
		{props.textAndLinks?.map((textAndLink, key) => <NavBarElement text={textAndLink.text} link={textAndLink.link} key={key} />)}
	</div>
}