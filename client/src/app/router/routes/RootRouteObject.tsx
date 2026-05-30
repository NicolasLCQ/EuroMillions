import {drawsRouteObject, homeRouteObject, NotFoundPage, notFoundRouteObject, RootPage, uploadRouteObject} from 'pages';
import {config} from 'config';
import {Navigate, RouteObject} from 'react-router-dom';

const homePath = homeRouteObject.path ?? '/home';
const drawsPath = drawsRouteObject.path ?? '/draws';
const uploadPath = uploadRouteObject.path ?? '/upload';

const rootNavigationLinks = [
  {
    text: 'Home',
    link: homePath,
  },
  {
    text: 'Draws',
    link: drawsPath,
  },
  {
    text: 'Statistics',
    link: '',
  },
  {
    text: 'Upload',
    link: uploadPath,
  },
];

const redirectOnHomePageByDefaultConfiguration = {
  index: true,
  element: <Navigate to={homePath} replace />,
};

const rootRouteObject: RouteObject = {
  path: '/',
  element: <RootPage applicationVersion={config.APPLICATION_VERSION} navigationLinks={rootNavigationLinks} />,
  errorElement: <NotFoundPage />,
  children: [redirectOnHomePageByDefaultConfiguration, uploadRouteObject, drawsRouteObject, homeRouteObject, notFoundRouteObject],
};

export default rootRouteObject;
