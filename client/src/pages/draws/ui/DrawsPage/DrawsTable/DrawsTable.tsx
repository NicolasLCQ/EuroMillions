import type {IDraw} from '@/shared/api';
import type {Table} from '@tanstack/react-table';
import {TableContent} from '@/shared/ui/table';
import {sortableTableFeatures} from '@/shared/lib/table';
import styles from './DrawsTable.module.css';

interface DrawsTableProps {
  table: Table<typeof sortableTableFeatures, IDraw>;
}

function DrawsTable({table}: DrawsTableProps) {
  return (
    <div className={styles.tableShell}>
      <table className={styles.drawsTable}>
        <thead>
          {table.getHeaderGroups().map((headerGroup) => (
            <tr key={headerGroup.id}>
              {headerGroup.headers.map((header) => {
                const sortDirection = header.column.getIsSorted();
                const sortArrow = sortDirection === 'asc' ? '↑' : '↓';
                const sortLabel = sortDirection === 'asc' ? 'ascending order' : 'descending order';

                return (
                  <th key={header.id} scope='col'>
                    {header.column.getCanSort() ? (
                      <button className={styles.sortButton} type='button' onClick={header.column.getToggleSortingHandler()}>
                        <TableContent content={header.column.columnDef.header} context={header.getContext()} />
                        <span aria-label={sortLabel}>{sortArrow}</span>
                      </button>
                    ) : (
                      <TableContent content={header.column.columnDef.header} context={header.getContext()} />
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
                <td key={cell.id} data-label={String(cell.column.columnDef.header)}>
                  <TableContent content={cell.column.columnDef.cell} context={cell.getContext()} />
                </td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default DrawsTable;
