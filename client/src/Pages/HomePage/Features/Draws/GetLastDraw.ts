import {config} from "../../../../Config";
import {IDraw} from "Models/DrawModels/IDraw.ts";

export interface IGetLastDrawResponse {
	isUpToDate: boolean;
	draw?: IDraw;
}

const isBodyEmpty = (body: string): boolean => !body.trim();

export const getLastDraw = async (): Promise<IGetLastDrawResponse | null> => {
	const baseUrl = config.API_URL;

	const httpResponse = await fetch(`${baseUrl}/draws/getlastdraw`, {
		method: "GET",
	});

	if (!httpResponse.ok) {
		throw new Error(`GetLastDraw failed with status ${httpResponse.status}`);
	}

	const body = await httpResponse.text();
	if (!isBodyEmpty(body)) {
		return null;
	}

	return JSON.parse(body) as IGetLastDrawResponse;
};
