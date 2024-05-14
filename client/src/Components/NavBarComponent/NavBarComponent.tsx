import './NavBarComponent.css';
import NavBarElement from "./NavBarElement/NavBarElement.tsx";

interface INavBarProps{
	textAndLinks?: {text: string; link: string}[];
}

export default function NavBarComponent(props:INavBarProps) {
	return <div className="NavBar">
		{props.textAndLinks?.map(textAndLink => <NavBarElement text={textAndLink.text} link={textAndLink.link}/>)}
	</div>
}