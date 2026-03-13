import { Outlet } from "react-router-dom";
import Header from "widgets/Header";
import NavBar from "widgets/NavBar";
import styles from "./RootPage.module.css";

export default function RootPage() {
	return(
		<div className={styles.rootPage}>
			<Header/>
			<div className={styles.pageBody}>
				<NavBar/>
				<main className={styles.content}>
					<Outlet />
				</main>
			</div>
		</div>
	)
}

