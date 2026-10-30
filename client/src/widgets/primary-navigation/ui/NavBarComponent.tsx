import styles from './NavBarComponent.module.css';
import NavBarElement from './NavBarElement';
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
      {props.textAndLinks?.map((textAndLink) => (
        <NavBarElement text={textAndLink.text} link={textAndLink.link} key={textAndLink.link || textAndLink.text} />
      ))}
    </div>
  );
};

export default NavBarComponent;
