import {useAreUpToDateQuery, useLastDrawQuery, useNextDrawDateQuery, useNextDrawEstimatedJackpotQuery} from 'api/hooks';
import {uploadRouteObject} from 'pages';
import {useNavigate} from 'react-router-dom';
import {PageTitleComponent} from 'shared/components';
import {IDraw, IFdjMoneyAmount} from 'shared/types';
import {IsUpToDateComponent} from './IsUpToDate';
import {LastDrawComponent} from './LastDraw';
import {NextDrawComponent} from './NextDraw';
import styles from './HomePage.module.css';

function HomePage() {
  const navigate = useNavigate();

  const getLastDrawQueryResult = useLastDrawQuery<IDraw>();
  const getAreUpToDateQueryResult = useAreUpToDateQuery();
  const getNextDrawQueryResult = useNextDrawDateQuery();
  const getNextDrawEstimatedJackpotQueryResult = useNextDrawEstimatedJackpotQuery<IFdjMoneyAmount>();

  const goToUploadPage = () => navigate(uploadRouteObject.path ?? '/upload');

  const isLoading =
    getLastDrawQueryResult.isLoading ||
    getAreUpToDateQueryResult.isLoading ||
    getNextDrawQueryResult.isLoading ||
    getNextDrawEstimatedJackpotQueryResult.isLoading;
  const isError = getAreUpToDateQueryResult.error || getNextDrawQueryResult.error || getNextDrawEstimatedJackpotQueryResult.error;

  if (isLoading) return <div>Loading...</div>;
  if (isError) return <div>Error while loading data.</div>;
  if (!getAreUpToDateQueryResult.data || !getNextDrawQueryResult.data) return <div>No data available.</div>;

  const areUpToDate = getAreUpToDateQueryResult.data.areUpToDate;
  const nextDrawDate = getNextDrawQueryResult.data.nextDrawDate;
  const estimatedJackpot = getNextDrawEstimatedJackpotQueryResult.data ?? null;

  return (
    <div className={styles.homePage}>
      <PageTitleComponent>Home Page</PageTitleComponent>
      <IsUpToDateComponent isUpToDate={areUpToDate} onClick={goToUploadPage} />
      <NextDrawComponent Date={nextDrawDate} estimatedJackpot={estimatedJackpot} />
      <LastDrawComponent Draw={getLastDrawQueryResult.data} />
    </div>
  );
}

export default HomePage;
