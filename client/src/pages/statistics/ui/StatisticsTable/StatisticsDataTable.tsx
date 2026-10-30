import {flexRender, type Table} from '@tanstack/react-table';
import styles from './StatisticsTable.module.css';

interface StatisticsDataTableProps<TData> {
  table: Table<TData>;
}

function StatisticsDataTable<TData>({table}: StatisticsDataTableProps<TData>) {
  return (
    <table className={styles.statisticsTable}>
      <thead>
        {table.getHeaderGroups().map((headerGroup) => (
          <tr key={headerGroup.id}>
            {headerGroup.headers.map((header) => {
              const sortDirection = header.column.getIsSorted();
              const sortLabel = sortDirection === 'asc' ? 'ascending' : sortDirection === 'desc' ? 'descending' : 'not sorted';
              const ariaSort = sortDirection === 'asc' ? 'ascending' : sortDirection === 'desc' ? 'descending' : 'none';

              return (
                <th key={header.id} scope='col' aria-sort={ariaSort}>
                  {header.isPlaceholder ? null : (
                    <button className={styles.sortButton} type='button' onClick={header.column.getToggleSortingHandler()}>
                      {flexRender(header.column.columnDef.header, header.getContext())}
                      <span className={styles.sortIndicator} aria-label={sortLabel}>
                        {sortDirection === 'asc' ? '↑' : sortDirection === 'desc' ? '↓' : '↕'}
                      </span>
                    </button>
                  )}
                </th>
              );
            })}
          </tr>
        ))}
      </thead>
      <tbody>
        {table.getRowModel().rows.map((row) => (
          <tr key={row.id}>
            {row.getVisibleCells().map((cell) => (
              <td key={cell.id}>{flexRender(cell.column.columnDef.cell, cell.getContext())}</td>
            ))}
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default StatisticsDataTable;
