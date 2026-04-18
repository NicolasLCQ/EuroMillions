import {API_ROUTES, euroMillionsFetch} from "./client";
import {IAreUpToDateResponse} from "shared/types";

export const getAreUpToDate = async (): Promise<IAreUpToDateResponse | null> => {

	const httpResponse = await euroMillionsFetch(API_ROUTES.areUpToDate, {
		method: "GET",
	});
	
	if (!httpResponse.ok) {
		throw new Error(`GetAreUpToDate failed with status ${httpResponse.status}`);
	}

	return await httpResponse.json() as IAreUpToDateResponse;
};

