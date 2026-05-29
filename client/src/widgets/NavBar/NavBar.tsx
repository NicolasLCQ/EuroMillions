import {NavBarComponent, type INavBarComponentLink} from 'shared/components';

export interface INavBarProps {
  textAndLinks: INavBarComponentLink[];
}

export default function NavBar(props: INavBarProps) {
  return <NavBarComponent textAndLinks={props.textAndLinks} />;
}
