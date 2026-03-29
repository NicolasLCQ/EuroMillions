import {API_ROUTES, euroMillionsFetch} from "./client";
import {IAreUpToDateResponse} from "shared/types/ResponseTypes/IAreUpToDateResponse.ts";

export const getAreUpToDate = async (): Promise<IAreUpToDateResponse | null> => {

	const httpResponse = await euroMillionsFetch(API_ROUTES.areUpToDate, {
		method: "GET",
	});
	
	if (!httpResponse.ok) {
		throw new Error(`GetLastDraw failed with status ${httpResponse.status}`);
	}

	return await httpResponse.json() as IAreUpToDateResponse;
};

