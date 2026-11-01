import type {IDraw} from '@/shared/api';
import {useState} from 'react';
import {useTable, type ColumnDef, type SortingState, type Updater} from '@tanstack/react-table';
import {sortableTableFeatures} from '@/shared/lib/table';

const DEFAULT_SORTING: SortingState = [{id: 'drawDate', desc: true}];

export function useDrawsTable(draws: IDraw[], columns: ColumnDef<typeof sortableTableFeatures, IDraw>[]) {
  const [sorting, setSorting] = useState<SortingState>(DEFAULT_SORTING);

  const handleSortingChange = (updater: Updater<SortingState>) => {
    setSorting((currentSorting) => {
      const nextSorting = typeof updater === 'function' ? updater(currentSorting) : updater;
      const drawDateSorting = nextSorting.find((sort) => sort.id === 'drawDate');

      return [{id: 'drawDate', desc: drawDateSorting?.desc ?? DEFAULT_SORTING[0].desc}];
    });
  };

  const table = useTable({
    features: sortableTableFeatures,
    data: draws,
    columns,
    state: {sorting},
    onSortingChange: handleSortingChange,
    enableSortingRemoval: false,
  });

  return table;
}
