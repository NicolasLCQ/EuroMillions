import {useQuery} from "@tanstack/react-query";
import {getLastDraw, IGetLastDrawResponse} from "../../Pages/HomePage/Features/Draws/GetLastDraw.ts";
import PageTitleComponent from "Components/TextComponents/PageTitleComponent/PageTitleComponent.tsx";
import LastDrawContainer from "Pages/HomePage/Containers/LastDrawContainer.tsx";
import PageErrorComponent from "Components/ErrorComponents/PageErrorComponents/PageErrorComponent.tsx";

function HomePage() {

	// aller fetch le back
	// -> base de donnée a jour ?
	// -> informations du dernier tirage
	const GetLastDrawQueryResult = useQuery({
		queryKey: ["api/Draws/GetLastDraw"],
		queryFn: getLastDraw,
	})

	// const isUpToDate = (GetLastDrawQueryResult.data as IGetLastDrawResponse).isUpToDate;

	return (
		<div className="HomePage">
			<PageTitleComponent>Home Page</PageTitleComponent>
			{GetLastDrawQueryResult.data && !(GetLastDrawQueryResult.data as IGetLastDrawResponse).isUpToDate &&
				<a href="/Uploa" className="UploadPageLink">
					<PageErrorComponent>Draws are not up to date !! go on Upload Page to update !!</PageErrorComponent>
				</a>}
			{/*message d'erreur si dernier tirage ou non + redirection vers la page upload*/}
			{/*gérer si base de donnée vide*/}
			{/*Affichage du dernier tirage avec date du tirage au-dessus*/}
			{GetLastDrawQueryResult.data &&
				<LastDrawContainer Draw={(GetLastDrawQueryResult.data as IGetLastDrawResponse).draw}/>}
		</div>
	);
}

export default HomePage
