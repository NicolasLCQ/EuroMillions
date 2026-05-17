import {useQuery} from "@tanstack/react-query";
import {PageTitleComponent} from "shared/components/TextComponents/PageTitleComponent";
import {LastDrawComponent} from "pages/HomePage/LastDraw";
import {IsUpToDateComponent} from "pages/HomePage/IsUpToDate";
import styles from "./HomePage.module.css";
import {IDraw} from "shared/types";
import {useNavigate} from "react-router-dom";
import {getLastDraw, getNextDrawEstimatedJackpot} from "api";
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

	const getNextDrawEstimatedJackpotQueryResult = useQuery({
		queryKey: ["nextDrawEstimatedJackpot"],
		queryFn: getNextDrawEstimatedJackpot,
	});

	const goToUploadPage = () => navigate(uploadRouteObject.path);

	const isLoading = getLastDrawQueryResult.isLoading || getAreUpToDateQueryResult.isLoading || getNextDrawQueryResult.isLoading || getNextDrawEstimatedJackpotQueryResult.isLoading;
	const isError = /*getLastDrawQueryResult.error ||*/ getAreUpToDateQueryResult.error || getNextDrawQueryResult.error || getNextDrawEstimatedJackpotQueryResult.error;
	// const areDatas = getLastDrawQueryResult.data;

	if (isLoading) return <div>Loading...</div>;
	if (isError) return <div>Error while loading data.</div>;
	// if (!areDatas) return <div>No data available.</div>;

	const areUpToDate = getAreUpToDateQueryResult.data.areUpToDate;
	//todo:: nextdrawdate is not precise enought !! 2026-05-12T21:45:00.000+02:00 is real time on the day !!
	const nextDrawDate = getNextDrawQueryResult.data.nextDrawDate;
	const estimatedJackpot = getNextDrawEstimatedJackpotQueryResult.data ?? null;

	return (
		<div className={styles.homePage}>
			<PageTitleComponent>Home Page</PageTitleComponent>
			<IsUpToDateComponent isUpToDate={areUpToDate} onClick={goToUploadPage}/>
			<NextDrawComponent Date={nextDrawDate} estimatedJackpot={estimatedJackpot}/>
			<LastDrawComponent Draw={getLastDrawQueryResult.data as IDraw}/>
		</div>
	);
}

export default HomePage


