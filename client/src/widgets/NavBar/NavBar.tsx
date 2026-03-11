import {INavBarComponentProps} from "shared/components/NavBarComponents/NavBarElements";
import NavBarComponent from "shared/components/NavBarComponents";
import {uploadRouteObject} from "pages/UploadPage";
import {homeRouteObject} from "pages/HomePage";

const NavBarInformations: INavBarComponentProps[] = [
	{
		text: "Home",
		link: homeRouteObject.path
	},
	{
		text: "Draws",
		link: ""
	},
	{
		text: "Statistics",
		link: ""
	},
	{
		text: "Upload",
		link: uploadRouteObject.path
	},
]

export default function NavBar() {
	return (
		<NavBarComponent textAndLinks={NavBarInformations}/>
	)
}


