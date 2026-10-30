import React from 'react';
import {BannerComponent} from '@/shared/ui/banner';

interface IPageErrorComponentProps extends React.PropsWithChildren {
  className?: string;
}

function PageErrorComponent(props: IPageErrorComponentProps) {
  return (
    <BannerComponent className={props.className} state='error'>
      {props.children}
    </BannerComponent>
  );
}

export default PageErrorComponent;
