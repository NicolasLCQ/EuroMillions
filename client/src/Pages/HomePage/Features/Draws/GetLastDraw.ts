import {config} from "../../../../Config";
import {IDraw} from "../../../../Models/DrawModels/IDraw.ts";

export interface IGetLastDrawResponse {
	//TODO: séparer les 2 appels !!
	isUpToDate: boolean;
	draw?: IDraw;
}

export const getLastDraw = async () => {
	const baseUrl = config.API_URL

	const httpResponse = await fetch(`${baseUrl}/draws/getlastdraw`, {
		method: 'GET'
	})

	if (!httpResponse.ok) {
		throw new Error(`GetLastDraw failed with status ${httpResponse.status}`);
	}

	return await httpResponse.json() as IGetLastDrawResponse;
}
