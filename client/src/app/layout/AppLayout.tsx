import {Outlet} from 'react-router-dom';
import {NavBar, type INavBarComponentLink} from '@/widgets/primary-navigation';
import {Header} from '@/widgets/site-header';
import styles from './AppLayout.module.css';

export interface AppLayoutProps {
  applicationVersion: string;
  navigationLinks: INavBarComponentLink[];
}

export default function AppLayout(props: AppLayoutProps) {
  return (
    <div className={styles.rootPage}>
      <Header version={props.applicationVersion} />
      <div className={styles.pageBody}>
        <NavBar textAndLinks={props.navigationLinks} />
        <main className={styles.content}>
          <Outlet />
        </main>
      </div>
    </div>
  );
}
