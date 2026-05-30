import {Outlet} from 'react-router-dom';
import {Header, NavBar} from 'widgets';
import type {INavBarComponentLink} from 'shared/components';
import styles from './RootPage.module.css';

export interface IRootPageProps {
  applicationVersion: string;
  navigationLinks: INavBarComponentLink[];
}

export default function RootPage(props: IRootPageProps) {
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
