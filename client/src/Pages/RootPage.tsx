import { Outlet } from "react-router-dom";
import Header from "../widgets/Header/Header.tsx";
import NavBar from "widgets/NavBar/NavBar.tsx";

export default function RootPage() {
	return(
		<>
			<Header/>
			<NavBar/>
			<Outlet />
		</>
	)
}
