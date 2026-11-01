import {useState} from 'react';
import {useTable, type ColumnDef, type SortingState} from '@tanstack/react-table';
import {sortableTableFeatures} from '@/shared/lib/table';
import type {IBallStatistics, IStarStatistics} from '../api/endpoints/statisticsResponse';

type Statistics = IBallStatistics | IStarStatistics;

export const getStatisticsNumber = (statistic: Statistics) => ('ball' in statistic ? statistic.ball : statistic.star);

export function useStatisticsTable(statistics: Statistics[], columns: ColumnDef<typeof sortableTableFeatures, Statistics>[]) {
  const [sorting, setSorting] = useState<SortingState>([{id: 'number', desc: false}]);

  const table = useTable({
    features: sortableTableFeatures,
    data: statistics,
    columns,
    getRowId: (statistic) => getStatisticsNumber(statistic).toString(),
    state: {sorting},
    onSortingChange: setSorting,
  });

  return table;
}
