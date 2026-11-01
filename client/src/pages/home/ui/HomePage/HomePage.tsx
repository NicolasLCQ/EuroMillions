import {useHomeDraws} from '../../model/useHomeDraws';
import {useUpdateDrawsNavigation} from '../../model/useUpdateDrawsNavigation';
import {PageTitleComponent} from '@/shared/ui/page-title';
import IsUpToDateComponent from './IsUpToDate/IsUpToDateComponent';
import LastDrawComponent from './LastDraw/LastDrawComponent';
import NextDrawComponent from './NextDraw/NextDrawComponent';
import styles from './HomePage.module.css';

function HomePage() {
  const {isLoading, isError, hasData, areUpToDate, nextDrawDate, estimatedJackpot, lastDraw} = useHomeDraws();
  const {goToUploadPage} = useUpdateDrawsNavigation();

  if (isLoading) return <div>Loading...</div>;
  if (isError) return <div>Error while loading data.</div>;
  if (!hasData) return <div>No data available.</div>;

  return (
    <div className={styles.homePage}>
      <PageTitleComponent>Home Page</PageTitleComponent>
      <IsUpToDateComponent isUpToDate={areUpToDate} onClick={goToUploadPage} />
      <NextDrawComponent Date={nextDrawDate} estimatedJackpot={estimatedJackpot} />
      <LastDrawComponent Draw={lastDraw} />
    </div>
  );
}

export default HomePage;
