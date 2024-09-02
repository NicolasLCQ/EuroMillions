import './NavBarComponent.css';
import NavBarElement from "./NavBarElements/NavBarElement.tsx";

interface INavBarProps{
	textAndLinks?: {text: string; link: string}[];
}

export default function NavBarComponent(props:INavBarProps) {
	return <div className="NavBar">
		{props.textAndLinks?.map((textAndLink, key) => <NavBarElement text={textAndLink.text} link={textAndLink.link} key={key} />)}
	</div>
}