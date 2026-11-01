import {getStatisticsNumber} from '../../../model/useStatisticsTable';
import {BallComponent, StarComponent} from '@/entities/draw';
import {sortableTableFeatures} from '@/shared/lib/table';
import type {ColumnDef} from '@tanstack/react-table';
import type {IBallStatistics, IStarStatistics} from '../../../api/endpoints/statisticsResponse';
import styles from './StatisticsTable.module.css';

type Statistics = IBallStatistics | IStarStatistics;

const decimalFormatter = new Intl.NumberFormat('en-GB', {
  minimumFractionDigits: 2,
  maximumFractionDigits: 2,
});

export const createStatisticsColumns = (itemType: 'ball' | 'star'): ColumnDef<typeof sortableTableFeatures, Statistics>[] => [
  {
    id: 'number',
    accessorFn: getStatisticsNumber,
    header: itemType === 'ball' ? 'Ball' : 'Star',
    cell: ({row}) => {
      const number = getStatisticsNumber(row.original);

      return itemType === 'ball' ? (
        <BallComponent number={number} className={styles.drawItem} />
      ) : (
        <StarComponent number={number} className={styles.drawItem} />
      );
    },
  },
  {
    accessorKey: 'nbTimesDraw',
    header: 'Times drawn',
  },
  {
    accessorKey: 'nbDrawsSinceLastOccurrence',
    header: 'Draws since last',
  },
  {
    accessorKey: 'averageNbDrawsBetweenOccurrences',
    header: 'Average interval',
    cell: ({getValue}) => decimalFormatter.format(Number(getValue())),
  },
  {
    accessorKey: 'minimumNbDrawsBetweenOccurrences',
    header: 'Minimum interval',
  },
  {
    accessorKey: 'maximumNbDrawsBetweenOccurrences',
    header: 'Maximum interval',
  },
  {
    accessorKey: 'varianceNbDrawsBetweenOccurrences',
    header: 'Variance',
    cell: ({getValue}) => decimalFormatter.format(Number(getValue())),
  },
  {
    accessorKey: 'standardDeviationNbDrawsBetweenOccurrences',
    header: 'Standard deviation',
    cell: ({getValue}) => decimalFormatter.format(Number(getValue())),
  },
];
