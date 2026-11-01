import {sortableTableFeatures} from '@/shared/lib/table';
import {TitleComponent} from '@/shared/ui/title';
import type {Table} from '@tanstack/react-table';
import type {IBallStatistics, IStarStatistics} from '../../../api/endpoints/statisticsResponse';
import StatisticsDataTable from './StatisticsDataTable/StatisticsDataTable';
import styles from './StatisticsTable.module.css';

interface StatisticsTableProps {
  title: string;
  itemType: 'ball' | 'star';
  count: number;
  table: Table<typeof sortableTableFeatures, IBallStatistics | IStarStatistics>;
}

function StatisticsTable({title, itemType, count, table}: StatisticsTableProps) {
  return (
    <section className={styles.section} aria-labelledby={`${itemType}-statistics-title`}>
      <TitleComponent className={styles.title}>
        <span id={`${itemType}-statistics-title`}>{title}</span>
        <span className={styles.count}>{count}</span>
      </TitleComponent>

      <div className={styles.tableShell}>
        <StatisticsDataTable table={table} />
      </div>
    </section>
  );
}

export default StatisticsTable;
