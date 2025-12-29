import {useQuery} from "@tanstack/react-query";
import {getLastDraw, IGetLastDrawResponse} from "../../Pages/HomePage/Features/Draws/GetLastDraw.ts";
import PageTitleComponent from "Components/TextComponents/PageTitleComponent/PageTitleComponent.tsx";
import LastDrawContainer from "Pages/HomePage/Containers/LastDrawContainer.tsx";
import IsUpToDateContainer from "Pages/HomePage/Containers/IsUpToDateContainer.tsx";

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
		<div className="HomePage">
			<PageTitleComponent>Home Page</PageTitleComponent>
			{GetLastDrawQueryResult.data &&
				<IsUpToDateContainer isUpToDate={(GetLastDrawQueryResult.data as IGetLastDrawResponse).isUpToDate}
				                     onClick={onIsUpToDateContainerClick}/>}
			{/*message d'erreur si dernier tirage ou non + redirection vers la page upload*/}
			{/*gérer si base de donnée vide*/}
			{/*Affichage du dernier tirage avec date du tirage au-dessus*/}
			{GetLastDrawQueryResult.data &&
				<LastDrawContainer Draw={(GetLastDrawQueryResult.data as IGetLastDrawResponse).draw}/>}
		</div>
	);
}

export default HomePage
