import {IGetAllDrawsResponse} from "shared/types";
import {API_ROUTES, euroMillionsFetch} from "./client";

export const getAllDraws = async (): Promise<IGetAllDrawsResponse> => {
	const httpResponse = await euroMillionsFetch(API_ROUTES.allDraws, {
		method: "GET",
	});

	if (!httpResponse.ok) {
		throw new Error(`GetAllDraws failed with status ${httpResponse.status}`);
	}

	return await httpResponse.json() as IGetAllDrawsResponse;
};
