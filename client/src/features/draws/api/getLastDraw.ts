import {config} from "app/config";
import {IDraw} from "features/draws/model/IDraw.ts";

const isBodyEmpty = (body: string): boolean => !body.trim();

//TODO:: toutes les features devraient etre dans le fichier app > features > data :: app/features/drawfeatures/getlastdraw.ts
export const getLastDraw = async (): Promise<IDraw | null> => {
	const baseUrl = config.API_URL;

	const httpResponse = await fetch(`${baseUrl}/draws/getlastdraw`, {
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
