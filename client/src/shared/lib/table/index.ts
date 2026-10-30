import {columnVisibilityFeature, createSortedRowModel, rowSortingFeature, tableFeatures} from '@tanstack/react-table';

export const sortableTableFeatures = tableFeatures({
  columnVisibilityFeature,
  rowSortingFeature,
  sortedRowModel: createSortedRowModel(),
});
