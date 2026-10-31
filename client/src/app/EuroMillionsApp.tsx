import './styles/global.css';
import {NotificationProvider} from '@/shared/ui/notification';
import {QueryProvider} from './init/query-provider';
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
