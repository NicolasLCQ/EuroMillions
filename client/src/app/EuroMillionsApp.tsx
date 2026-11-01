import './styles/global.css';
import {NotificationProvider} from '@/shared/ui/notification';
import {QueryProvider} from './init/query-provider';
import {EuroMillionsRouter} from './router';
import {QueryDevtools} from '@/shared/ui/query-devtools';

const EuroMillionsApp = () => (
  <QueryProvider>
    <NotificationProvider>
      <EuroMillionsRouter />
      <QueryDevtools />
    </NotificationProvider>
  </QueryProvider>
);

export default EuroMillionsApp;
