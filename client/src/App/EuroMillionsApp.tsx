import './const.css';
import QueryProvider from "./Providers/QueryProvider/QueryProvider.tsx";
import EuroMillionsRouter from "./Router/EuroMillionsRouter.tsx";
import {ReactQueryDevtools} from "@tanstack/react-query-devtools";

const EuroMillionsApp = () => (
	<QueryProvider>
		<EuroMillionsRouter/>
		<ReactQueryDevtools initialIsOpen={false} />
	</QueryProvider>
)

export default EuroMillionsApp;