import './styles/global.css';
import {NotificationProvider, QueryProvider} from './providers';
import {EuroMillionsRouter} from './router';
import {ReactQueryDevtools} from '@tanstack/react-query-devtools';

const EuroMillionsApp = () => (
  <QueryProvider>
    <NotificationProvider>
      <EuroMillionsRouter />
      <ReactQueryDevtools initialIsOpen={false} />
    </NotificationProvider>
  </QueryProvider>
);

export default EuroMillionsApp;
