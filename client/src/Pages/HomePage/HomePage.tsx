import {useQuery} from "@tanstack/react-query";
import {getLastDraw} from "Pages/HomePage/Features/Draws/GetLastDraw.ts";
import PageTitleComponent from "Components/TextComponents/PageTitleComponent/PageTitleComponent.tsx";
import LastDrawContainer from "Pages/HomePage/Containers/LastDrawContainer.tsx";
import IsUpToDateContainer from "Pages/HomePage/Containers/IsUpToDateContainer.tsx";
import styles from "./HomePage.module.css";
import {IDraw} from "Models/DrawModels/IDraw.ts";

function HomePage() {

	// aller fetch le back
	// -> base de donnée a jour ?
	// -> informations du dernier tirage
	const GetLastDrawQueryResult = useQuery({
		queryKey: ["api/Draws/GetLastDraw"],
		queryFn: getLastDraw,
	})

	const onIsUpToDateContainerClick = () => window.location.href = "/Upload";

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

			{/*TODO: New route : isUpToDate*/}
			{/*{GetLastDrawQueryResult.data &&*/}
			{/*	<IsUpToDateContainer isUpToDate={(GetLastDrawQueryResult.data)}*/}
			{/*	                     onClick={onIsUpToDateContainerClick}/>}*/}

			{/*TODO: transformer en composant :: virer tout ce qui se nomme container ? */}
			{/*{GetLastDrawQueryResult.data &&*/}
			{/*	<LastDrawContainer Draw={(GetLastDrawQueryResult.data as IDraw)}/>}*/}
		</div>
	);
}

export default HomePage
