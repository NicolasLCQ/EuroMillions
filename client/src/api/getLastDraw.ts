import {IDraw} from "shared/types";
import {API_ROUTES, euroMillionsFetch} from "./client";

export const getLastDraw = async (): Promise<IDraw | null> => {

	const httpResponse = await euroMillionsFetch(API_ROUTES.lastDraw, {
		method: "GET",
	});

	if (!httpResponse.ok) {
		throw new Error(`GetLastDraw failed with status ${httpResponse.status}`);
	}

	return await httpResponse.json() as IDraw;
};

