import './const.css';
import QueryProvider from "./Providers/QueryProvider/QueryProvider.tsx";
import EuroMillionsRouter from "./Router/EuroMillionsRouter.tsx";

const EuroMillionsApp = () => (
	<QueryProvider>
		<EuroMillionsRouter/>
	</QueryProvider>
)

export default EuroMillionsApp;