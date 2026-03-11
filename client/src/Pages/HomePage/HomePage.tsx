import {useQuery} from "@tanstack/react-query";
import {getLastDraw} from "api";
import PageTitleComponent from "shared/components/TextComponents/PageTitleComponent";
import LastDrawComponent from "pages/HomePage/LastDraw";
import IsUpToDateComponent from "pages/HomePage/IsUpToDate";
import styles from "./HomePage.module.css";
import {IDraw} from "shared/types";

function HomePage() {

	// aller fetch le back
	// -> base de donnée a jour ?
	// -> informations du dernier tirage
	const getLastDrawQueryResult = useQuery({
		queryKey: ["api/Draws/GetLastDraw"],
		queryFn: getLastDraw,
	})

	const onIsUpToDateComponentClick = () => window.location.href = "/upload";

	return (
		<div className={styles.homePage}>
			<PageTitleComponent>Home Page</PageTitleComponent>
			{/*todo :: enlever se composant ! utiliser uniquement is up to date et utiliser bannererror*/}
			{getLastDrawQueryResult.data && (
				<IsUpToDateComponent
					isUpToDate={false}
					onClick={onIsUpToDateComponentClick}
				/>
			)}
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


