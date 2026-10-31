import {Outlet} from 'react-router-dom';
import NavBar from './primary-navigation/NavBar';
import type {INavBarComponentLink} from './primary-navigation/NavBarComponent';
import Header from './site-header/Header';
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
