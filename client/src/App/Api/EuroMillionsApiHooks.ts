import ApiGetFunction from "App/Api/ApiCalls/ApiGetFunction.ts";
import ApiPostFunction from "App/Api/ApiCalls/ApiPostFunction.ts";

interface IUseEuroMillionsApiType{
	Get: <Type>(url: string) => Promise<Type | Error>,
	Post: (url: string, body: FormData) => Promise<Response | Error>
}

const useEuroMillionsApi: () => IUseEuroMillionsApiType = () => {

	return {
		Get:ApiGetFunction,
		Post:ApiPostFunction
	};
}

export default useEuroMillionsApi;