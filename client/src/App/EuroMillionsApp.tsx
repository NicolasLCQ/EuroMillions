import './const.css';
import QueryProvider from "./Providers/QueryProvider/QueryProvider.tsx";
import EuroMillionsRouter from "./Router/EuroMillionsRouter.tsx";
import EnvironmentProvider from "./Providers/EnvironmentProvider/EnvironmentProvider.tsx";

const EuroMillionsApp = () => (
	<EnvironmentProvider>
		<QueryProvider>
			<EuroMillionsRouter/>
		</QueryProvider>
	</EnvironmentProvider>

)

export default EuroMillionsApp;