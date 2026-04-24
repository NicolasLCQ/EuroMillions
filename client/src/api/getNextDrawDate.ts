import {API_ROUTES, euroMillionsFetch} from "./client";
import {IGetNextDrawDateResponse} from "shared/types/ResponseTypes/IGetNextDrawDateResponse.ts";

export const getNextDrawDate = async (): Promise<IGetNextDrawDateResponse | null> => {

	const httpResponse = await euroMillionsFetch(API_ROUTES.nextDrawDate, {
		method: "GET",
	});
	
	if (!httpResponse.ok) {
		throw new Error(`GetAreUpToDate failed with status ${httpResponse.status}`);
	}

	return await httpResponse.json() as IGetNextDrawDateResponse;
};

