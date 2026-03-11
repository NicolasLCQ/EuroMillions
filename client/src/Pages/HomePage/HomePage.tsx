import {useQuery} from "@tanstack/react-query";
import {getLastDraw} from "features/draws/api/getLastDraw.ts";
import PageTitleComponent from "shared/ui/TextComponents/PageTitleComponent/PageTitleComponent.tsx";
import LastDrawComponent from "features/draws/components/LastDrawComponent.tsx";
import IsUpToDateComponent from "features/draws/components/IsUpToDateComponent.tsx";
import styles from "./HomePage.module.css";
import {IDraw} from "features/draws/model/IDraw.ts";

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
			{/*message d'erreur si dernier tirage + redirection vers la page upload*/}
			{/*gérer si base de donnée vide && dernier tirage ok => la base de donnée 'est pas a jour + redirection vers la page upload*/}

			{/*DATE DU PROCHAIN TIRAGE*/}
			{/*SOMME A GAGNER ??*/}

			{/*TITRE :: DERNIER TIRAGE*/}
			{/*Affichage du dernier tirage */}
			{/*date du tirage au-dessus*/}

			{getLastDrawQueryResult.data && (
				<IsUpToDateComponent
					isUpToDate={Boolean(getLastDrawQueryResult.data)}
					onClick={onIsUpToDateComponentClick}
				/>
			)}

			{getLastDrawQueryResult.data && (
				<LastDrawComponent Draw={getLastDrawQueryResult.data as IDraw}/>
			)}
		</div>
	);
}

export default HomePage

