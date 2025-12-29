import {config} from "../../../../Config";
import {IDraw} from "../../../../Models/DrawModels/IDraw.ts";

export interface IGetLastDrawResponse {
	isUpToDate: boolean;
	draw?: IDraw;
}

export const getLastDraw = async () => {
	const baseUrl = config.API_URL

	const httpResponse = await fetch(`${baseUrl}/draws/getlastdraw`, {
		method: 'GET'
	})

	if (httpResponse.ok) {
		return await httpResponse.json() as IGetLastDrawResponse;
	}

	return await httpResponse.json() as Error;
}
