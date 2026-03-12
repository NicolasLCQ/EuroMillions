import { config } from "app/config";

const API_BASE_URL = config.API_URL.replace(/\/$/, "");

async function euroMillionsFetch(endpoint: string, init?: RequestInit): Promise<Response> {
	return await fetch(`${API_BASE_URL}${endpoint}`, init);
}

export default euroMillionsFetch