import {useQuery} from "@tanstack/react-query";
import {getLastDraw, IGetLastDrawResponse} from "../../Pages/HomePage/Features/Draws/GetLastDraw.ts";
import DrawComponent from "../../Components/DrawComponents/DrawComponent.tsx";
import PageTitleComponent from "Components/TextComponents/PageTitleComponent/PageTitleComponent.tsx";

function HomePage() {

	// aller fetch le back
	// -> base de donnée a jour ?
	// -> informations du dernier tirage
	const lastDraw = useQuery({
		queryKey: ["api/Draws/GetLastDraw"],
		queryFn: getLastDraw
	})

	return (
		<div className="HomePage">
			<PageTitleComponent>Home Page</PageTitleComponent>
			{/*message d'erreur si dernier tirage ou non + redirection vers la page upload*/}
			{/*gérer si base de donnée vide*/}
			{/*Affichage du dernier tirage avec date du tirage au-dessus*/}
			{/* à envoyer dans un container*/}
			{lastDraw.data && <DrawComponent Draw={(lastDraw.data as IGetLastDrawResponse).draw}/>}
		</div>
	);
}

export default HomePage
