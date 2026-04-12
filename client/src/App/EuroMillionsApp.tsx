import './styles/global.css';
import { QueryProvider } from "./providers/query-provider";
import {NotificationProvider} from "./providers/notification-provider";
import { EuroMillionsRouter } from "./router";
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

