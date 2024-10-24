import { createContext } from "react";
import {IEnvVariablesType} from "./EnvVariables/EnvVariables.ts";

const ENV = import.meta.env;

export interface IEnvironmentContextProps {
	useEnvVariables: () => IEnvVariablesType;
}

const EnvironmentContext = createContext<IEnvironmentContextProps>({
	useEnvVariables: () => null,
});

export interface IEnvironmentProviderProps {
	children: React.ReactNode;
}

const EnvironmentProvider = ({children}:IEnvironmentProviderProps) => {

	const useEnvVariables = () => {
		return {
			env: ENV.MODE,
			api: {
				baseURL: ENV.VITE_API_URL
			}
		}
	};

	return (
		<EnvironmentContext.Provider value={{useEnvVariables}}>
			{children}
		</EnvironmentContext.Provider>
	)
}

export default EnvironmentProvider;