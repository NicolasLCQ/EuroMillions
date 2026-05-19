import {BannerComponent} from 'shared/components';

export interface DrawStatusBannerComponentProps {
  areUpToDate?: boolean;
  isError: boolean;
  isLoading: boolean;
}

function DrawStatusBannerComponent(props: DrawStatusBannerComponentProps) {
  if (props.isLoading) {
    return <BannerComponent state='information'>Checking draw status...</BannerComponent>;
  }

  if (props.isError || props.areUpToDate === undefined) {
    return <BannerComponent state='error'>Unable to check whether draws are up to date.</BannerComponent>;
  }

  if (props.areUpToDate) {
    return <BannerComponent state='success'>Draws are up to date.</BannerComponent>;
  }

  return (
    <BannerComponent state='error'>
      Draws are not up to date. Add the latest FDJ files or run the automatic update.
    </BannerComponent>
  );
}

export default DrawStatusBannerComponent;
