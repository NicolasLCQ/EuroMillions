import './styles/global.css';
import QueryProvider from "./providers/query-provider";
import EuroMillionsRouter from "./router";
import {ReactQueryDevtools} from "@tanstack/react-query-devtools";

const EuroMillionsApp = () => (
	<QueryProvider>
		<EuroMillionsRouter/>
		<ReactQueryDevtools initialIsOpen={false} />
	</QueryProvider>
)

export default EuroMillionsApp;

