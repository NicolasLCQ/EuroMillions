import {useQuery} from "@tanstack/react-query";
import {PageTitleComponent} from "shared/components/TextComponents/PageTitleComponent";
import {LastDrawComponent} from "pages/HomePage/LastDraw";
import {IsUpToDateComponent} from "pages/HomePage/IsUpToDate";
import styles from "./HomePage.module.css";
import {IDraw} from "shared/types";
import {useNavigate} from "react-router-dom";
import {getLastDraw} from "api";
import {uploadRouteObject} from "pages";
import {API_ROUTES} from "api/client";
import {getAreUpToDate} from "api/getAreUpToDate.ts";
import {getNextDrawDate} from "api/getNextDrawDate.ts";
import {NextDrawComponent} from "pages/HomePage/NextDraw";

function HomePage() {
	const navigate = useNavigate();

	const getLastDrawQueryResult = useQuery({
		queryKey: [API_ROUTES.lastDraw],
		queryFn: getLastDraw,
	});

	const getAreUpToDateQueryResult = useQuery({
		queryKey: [API_ROUTES.areUpToDate],
		queryFn: getAreUpToDate,
	});

	const getNextDrawQueryResult = useQuery({
		queryKey: [API_ROUTES.nextDrawDate],
		queryFn: getNextDrawDate,

	})

	const goToUploadPage = () => navigate(uploadRouteObject.path);

	const isLoading = getLastDrawQueryResult.isLoading || getAreUpToDateQueryResult.isLoading || getNextDrawQueryResult.isLoading;
	const isError = getLastDrawQueryResult.error || getAreUpToDateQueryResult.error || getNextDrawQueryResult.error;
	const areDatas = getLastDrawQueryResult.data && getAreUpToDateQueryResult.data || getNextDrawQueryResult.data;

	if (isLoading) return <div>Loading...</div>;
	if (isError) return <div>Error while loading data.</div>;
	if (!areDatas) return <div>No data available.</div>;

	const areUpToDate = getAreUpToDateQueryResult.data.areUpToDate;
	const nextDrawDate = getNextDrawQueryResult.data.nextDrawDate;

	return (
		<div className={styles.homePage}>
			<PageTitleComponent>Home Page</PageTitleComponent>
			<IsUpToDateComponent isUpToDate={areUpToDate} onClick={goToUploadPage}/>
			<NextDrawComponent Date={nextDrawDate}/>
			{/*DATE DU PROCHAIN TIRAGE*/}
			{/*SOMME A GAGNER ??*/}

			{/*TITRE :: DERNIER TIRAGE*/}
			{/*Affichage du dernier tirage */}
			{/*date du tirage au-dessus*/}


			<LastDrawComponent Draw={getLastDrawQueryResult.data as IDraw}/>
		</div>
	);
}

export default HomePage



