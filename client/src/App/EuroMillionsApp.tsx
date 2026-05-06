import './styles/global.css';
import { QueryProvider } from "./Providers/query-provider";
import {NotificationProvider} from "./Providers/notification-provider";
import { EuroMillionsRouter } from "./Router";
import {ReactQueryDevtools} from "@tanstack/react-query-devtools";

const EuroMillionsApp = () => (
	<QueryProvider>
		<NotificationProvider>
			<EuroMillionsRouter/>
			<ReactQueryDevtools initialIsOpen={false} />
		</NotificationProvider>
	</QueryProvider>
)

export default EuroMillionsApp;

