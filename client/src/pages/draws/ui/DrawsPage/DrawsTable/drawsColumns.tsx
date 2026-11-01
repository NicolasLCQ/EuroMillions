import type {IDraw} from '@/shared/api';
import type {ColumnDef} from '@tanstack/react-table';
import {BallComponent, StarComponent} from '@/entities/draw';
import {sortableTableFeatures} from '@/shared/lib/table';
import styles from './DrawsTable.module.css';

const formatDate = (drawDate: string) =>
  new Intl.DateTimeFormat('en-GB', {
    day: '2-digit',
    month: '2-digit',
    year: 'numeric',
  }).format(new Date(drawDate));

const getBalls = (draw: IDraw) => [draw.ball1, draw.ball2, draw.ball3, draw.ball4, draw.ball5];
const getStars = (draw: IDraw) => [draw.star1, draw.star2];
const formatAdditionalGame = (value?: string) => (value ? value.replace(/,\s*/g, ',\n') : '-');

export const drawsColumns: ColumnDef<typeof sortableTableFeatures, IDraw>[] = [
  {
    id: 'drawDate',
    accessorFn: (draw) => new Date(draw.drawDate).getTime(),
    header: 'Date',
    cell: ({row}) => (
      <div className={styles.dateCell}>
        <strong>{formatDate(row.original.drawDate)}</strong>
        <span>Draw #{row.original.drawNumber}</span>
      </div>
    ),
  },
  {
    id: 'balls',
    header: 'Balls',
    enableSorting: false,
    cell: ({row}) => (
      <div className={styles.resultGroup} aria-label={`Balls for draw ${row.original.drawNumber}`}>
        {getBalls(row.original).map((ball) => (
          <BallComponent key={ball} number={ball} className={styles.drawBall} />
        ))}
      </div>
    ),
  },
  {
    id: 'stars',
    header: 'Stars',
    enableSorting: false,
    cell: ({row}) => (
      <div className={styles.resultGroup} aria-label={`Stars for draw ${row.original.drawNumber}`}>
        {getStars(row.original).map((star) => (
          <StarComponent key={star} number={star} className={styles.drawStar} />
        ))}
      </div>
    ),
  },
  {
    id: 'jokerPlusNumber',
    header: 'Joker+',
    enableSorting: false,
    cell: ({row}) => <span className={styles.additionalGame}>{formatAdditionalGame(row.original.jokerPlusNumber)}</span>,
  },
  {
    id: 'myMillionNumber',
    header: 'My Million',
    enableSorting: false,
    cell: ({row}) => <span className={styles.additionalGame}>{formatAdditionalGame(row.original.myMillionNumber)}</span>,
  },
  {
    id: 'exceptionalEuroMillionsDrawNumber',
    header: 'Exceptional',
    enableSorting: false,
    cell: ({row}) => (
      <span className={styles.additionalGame}>{formatAdditionalGame(row.original.exceptionalEuroMillionsDrawNumber)}</span>
    ),
  },
];
