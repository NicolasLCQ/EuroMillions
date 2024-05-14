import { Outlet } from "react-router-dom";
import Header from "./Header/Header.tsx";
import NavBar from "./NavBar/NavBar.tsx";

export default function RootPage() {
	return(
		<>
			<Header/>
			<NavBar/>
			<Outlet />
		</>
	)
}