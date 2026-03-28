import {useQuery} from "@tanstack/react-query";
import {PageTitleComponent} from "shared/components/TextComponents/PageTitleComponent";
import {LastDrawComponent} from "pages/HomePage/LastDraw";
import {IsUpToDateComponent} from "pages/HomePage/IsUpToDate";
import styles from "./HomePage.module.css";
import {IDraw} from "shared/types";
import {useNavigate} from "react-router-dom";
import {getLastDraw} from "api";
import {uploadRouteObject} from "pages";

function HomePage() {
	const navigate = useNavigate();

	// aller fetch le back
	// -> base de donnée a jour ?
	// -> informations du dernier tirage
	const getLastDrawQueryResult = useQuery({
		queryKey: ["api/Draws/GetLastDraw"],
		queryFn: getLastDraw,
	})

	const goToUploadPage = () => navigate(uploadRouteObject.path);
	const isUpToDate = false;

	return (
		<div className={styles.homePage}>
			<PageTitleComponent>Home Page</PageTitleComponent>
			<IsUpToDateComponent isUpToDate={isUpToDate} onClick={goToUploadPage}/>

			{/*DATE DU PROCHAIN TIRAGE*/}
			{/*SOMME A GAGNER ??*/}

			{/*TITRE :: DERNIER TIRAGE*/}
			{/*Affichage du dernier tirage */}
			{/*date du tirage au-dessus*/}


			{getLastDrawQueryResult.data && (
				<LastDrawComponent Draw={getLastDrawQueryResult.data as IDraw}/>
			)}
		</div>
	);
}

export default HomePage


