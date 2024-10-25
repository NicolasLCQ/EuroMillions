import { createContext } from "react";
import {IEnvVariablesType, mappedEnvVariables} from "./EnvVariables/EnvVariables.ts";

export interface IEnvironmentContextProps {
	useEnvVariables: () => IEnvVariablesType;
}

const EnvironmentContext = createContext<IEnvironmentContextProps>({
	useEnvVariables: () => null,
});

export interface IEnvironmentProviderProps {
	children: React.ReactNode;
	mapedEnvVariables: IEnvVariablesType;
}

const EnvironmentProvider = ({children, mapedEnvVariables=mappedEnvVariables }:IEnvironmentProviderProps) => {

	const useEnvVariables = () => mapedEnvVariables;

	return (
		<EnvironmentContext.Provider value={{useEnvVariables}}>
			{children}
		</EnvironmentContext.Provider>
	)
}

export default EnvironmentProvider;