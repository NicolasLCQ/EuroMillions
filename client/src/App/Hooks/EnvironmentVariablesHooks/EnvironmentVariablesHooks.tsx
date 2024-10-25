
import {IEnvVariablesType, mappedEnvVariables} from "./EnvVariables/EnvVariables.ts";

export const useEnvVariables: () => IEnvVariablesType = () => mappedEnvVariables;