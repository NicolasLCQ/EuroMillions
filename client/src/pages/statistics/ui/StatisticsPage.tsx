import {PageTitleComponent} from '@/shared/ui/page-title';
import {TextComponent} from '@/shared/ui/text';
import {useStatisticsQuery} from '../api/useStatisticsQuery';
import StatisticsTable from './StatisticsTable/StatisticsTable';
import styles from './StatisticsPage.module.css';

function StatisticsPage() {
  const {data, isLoading, isError} = useStatisticsQuery();

  if (isLoading) return <TextComponent>Loading statistics...</TextComponent>;
  if (isError) return <TextComponent>Error while loading statistics.</TextComponent>;

  const balls = data?.balls ?? [];
  const stars = data?.stars ?? [];
  const hasStatistics = balls.length > 0 || stars.length > 0;

  return (
    <div className={styles.statisticsPage}>
      <header className={styles.header}>
        <PageTitleComponent>Statistics</PageTitleComponent>
        <TextComponent>Occurrence and interval statistics calculated from the draw history.</TextComponent>
      </header>

      {!hasStatistics ? (
        <TextComponent>No statistics found.</TextComponent>
      ) : (
        <div className={styles.tables}>
          {balls.length > 0 && <StatisticsTable title='Balls' itemType='ball' statistics={balls} />}
          {stars.length > 0 && <StatisticsTable title='Stars' itemType='star' statistics={stars} />}
        </div>
      )}
    </div>
  );
}

export default StatisticsPage;
