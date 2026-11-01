import {useStatisticsTable} from '../../model/useStatisticsTable';
import {createStatisticsColumns} from './StatisticsTable/statisticsColumns';
import {PageTitleComponent} from '@/shared/ui/page-title';
import {TextComponent} from '@/shared/ui/text';
import {useStatistics} from '../../model/useStatistics';
import StatisticsTable from './StatisticsTable/StatisticsTable';
import styles from './StatisticsPage.module.css';

const ballColumns = createStatisticsColumns('ball');
const starColumns = createStatisticsColumns('star');

function StatisticsPage() {
  const {balls, stars, hasStatistics, isLoading, isError} = useStatistics();
  const ballsTable = useStatisticsTable(balls, ballColumns);
  const starsTable = useStatisticsTable(stars, starColumns);

  if (isLoading) return <TextComponent>Loading statistics...</TextComponent>;
  if (isError) return <TextComponent>Error while loading statistics.</TextComponent>;

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
          {balls.length > 0 && <StatisticsTable title='Balls' itemType='ball' count={balls.length} table={ballsTable} />}
          {stars.length > 0 && <StatisticsTable title='Stars' itemType='star' count={stars.length} table={starsTable} />}
        </div>
      )}
    </div>
  );
}

export default StatisticsPage;
