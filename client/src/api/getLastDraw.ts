import {IDraw} from "shared/types";
import {euroMillionsFetch, API_ROUTES} from "./client";

const isBodyEmpty = (body: string): boolean => !body.trim();

export const getLastDraw = async (): Promise<IDraw | null> => {

	const httpResponse = await euroMillionsFetch(API_ROUTES.lastDraw, {
		method: "GET",
	});

	if (!httpResponse.ok) {
		throw new Error(`GetLastDraw failed with status ${httpResponse.status}`);
	}

	const body = await httpResponse.text();
	if (isBodyEmpty(body)) {
		return null;
	}

	return await httpResponse.json() as IDraw;
};

