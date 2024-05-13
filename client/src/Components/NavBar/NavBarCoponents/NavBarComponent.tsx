interface INavBarComponentProps {
	navBarComponentText: string;
}

export default function NavBarComponent(props: INavBarComponentProps) {
	return (
		<div className="NavBarElement">
			{props.navBarComponentText}
		</div>
	)
}