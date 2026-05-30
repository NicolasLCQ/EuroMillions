import styles from './NavBarComponent.module.css';
import {NavBarElement} from './NavBarElements';
import React from 'react';

export interface INavBarComponentLink {
  text: string;
  link: string;
}

export interface INavBarComponentProps {
  textAndLinks?: INavBarComponentLink[];
}

const NavBarComponent: React.FC<INavBarComponentProps> = (props: INavBarComponentProps) => {
  return (
    <div className={styles.navBar}>
      {props.textAndLinks?.map((textAndLink, key) => (
        <NavBarElement text={textAndLink.text} link={textAndLink.link} key={key} />
      ))}
    </div>
  );
};

export default NavBarComponent;
