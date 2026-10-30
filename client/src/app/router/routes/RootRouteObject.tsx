import {DrawsPage} from '@/pages/draws';
import {HomePage} from '@/pages/home';
import {NotFoundPage} from '@/pages/not-found';
import {StatisticsPage} from '@/pages/statistics';
import {UpdateDrawsPage} from '@/pages/update-draws';
import {config} from '@/shared/config';
import {ROUTES} from '@/shared/routes';
import {Navigate, type RouteObject} from 'react-router-dom';
import AppLayout from '../../layout/AppLayout';

const rootNavigationLinks = [
  {
    text: 'Home',
    link: ROUTES.home,
  },
  {
    text: 'Draws',
    link: ROUTES.draws,
  },
  {
    text: 'Statistics',
    link: ROUTES.statistics,
  },
  {
    text: 'Upload',
    link: ROUTES.updateDraws,
  },
];

const redirectOnHomePageByDefaultConfiguration = {
  index: true,
  element: <Navigate to={ROUTES.home} replace />,
};

const rootRouteObject: RouteObject = {
  path: '/',
  element: <AppLayout applicationVersion={config.APPLICATION_VERSION} navigationLinks={rootNavigationLinks} />,
  errorElement: <NotFoundPage />,
  children: [
    redirectOnHomePageByDefaultConfiguration,
    {path: ROUTES.home, element: <HomePage />},
    {path: ROUTES.draws, element: <DrawsPage />},
    {path: ROUTES.statistics, element: <StatisticsPage />},
    {path: ROUTES.updateDraws, element: <UpdateDrawsPage />},
    {path: '*', element: <NotFoundPage />},
  ],
};

export default rootRouteObject;
