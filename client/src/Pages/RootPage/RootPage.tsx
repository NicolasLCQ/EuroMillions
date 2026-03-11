import { Outlet } from "react-router-dom";
import Header from "widgets/Header";
import NavBar from "widgets/NavBar";

export default function RootPage() {
	return(
		<>
			<Header/>
			<NavBar/>
			<Outlet />
		</>
	)
}

