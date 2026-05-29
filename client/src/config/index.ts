import appConfig from './appsettings.json';
import packageJson from '../../package.json';

export const config = {
  ...appConfig,
  APPLICATION_VERSION: packageJson.version,
};
