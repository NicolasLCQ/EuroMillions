import {BallComponent, StarComponent, type IBallStatistics, type IStarStatistics} from '@/entities/draw';
import {TitleComponent} from '@/shared/ui/title';
import {getCoreRowModel, getSortedRowModel, useReactTable, type ColumnDef, type SortingState} from '@tanstack/react-table';
import {useMemo, useState} from 'react';
import StatisticsDataTable from './StatisticsDataTable';
import styles from './StatisticsTable.module.css';

type Statistics = IBallStatistics | IStarStatistics;

interface StatisticsTableProps {
  title: string;
  itemType: 'ball' | 'star';
  statistics: Statistics[];
}

const decimalFormatter = new Intl.NumberFormat('en-GB', {
  minimumFractionDigits: 2,
  maximumFractionDigits: 2,
});

const getNumber = (statistic: Statistics) => ('ball' in statistic ? statistic.ball : statistic.star);

function StatisticsTable({title, itemType, statistics}: StatisticsTableProps) {
  const [sorting, setSorting] = useState<SortingState>([{id: 'number', desc: false}]);

  const columns = useMemo<ColumnDef<Statistics>[]>(
    () => [
      {
        id: 'number',
        accessorFn: getNumber,
        header: itemType === 'ball' ? 'Ball' : 'Star',
        cell: ({row}) => {
          const number = getNumber(row.original);

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
    ],
    [itemType],
  );

  const table = useReactTable({
    data: statistics,
    columns,
    getRowId: (statistic) => getNumber(statistic).toString(),
    state: {sorting},
    onSortingChange: setSorting,
    getCoreRowModel: getCoreRowModel(),
    getSortedRowModel: getSortedRowModel(),
  });

  return (
    <section className={styles.section} aria-labelledby={`${itemType}-statistics-title`}>
      <TitleComponent className={styles.title}>
        <span id={`${itemType}-statistics-title`}>{title}</span>
        <span className={styles.count}>{statistics.length}</span>
      </TitleComponent>

      <div className={styles.tableShell}>
        <StatisticsDataTable table={table} />
      </div>
    </section>
  );
}

export default StatisticsTable;
