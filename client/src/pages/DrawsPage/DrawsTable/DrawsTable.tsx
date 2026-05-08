import {useMemo, useState} from "react";
import {
	flexRender,
	getCoreRowModel,
	getSortedRowModel,
	useReactTable,
	type ColumnDef,
	type SortingState,
	type Updater,
} from "@tanstack/react-table";
import {BallComponent, StarComponent} from "shared/components";
import {IDraw} from "shared/types";
import styles from "./DrawsTable.module.css";

interface DrawsTableProps {
	draws: IDraw[];
}

const DEFAULT_SORTING: SortingState = [{id: "drawDate", desc: true}];

const formatDate = (drawDate: string) => new Intl.DateTimeFormat("en-GB", {
	day: "2-digit",
	month: "2-digit",
	year: "numeric",
}).format(new Date(drawDate));

const getBalls = (draw: IDraw) => [draw.ball1, draw.ball2, draw.ball3, draw.ball4, draw.ball5];
const getStars = (draw: IDraw) => [draw.star1, draw.star2];
const formatAdditionalGame = (value?: string) => value ? value.replace(/,\s*/g, ",\n") : "-";

function DrawsTable({draws}: DrawsTableProps) {
	const [sorting, setSorting] = useState<SortingState>(DEFAULT_SORTING);

	const columns = useMemo<ColumnDef<IDraw>[]>(() => [
		{
			id: "drawDate",
			accessorFn: draw => new Date(draw.drawDate).getTime(),
			header: "Date",
			cell: ({row}) => (
				<div className={styles.dateCell}>
					<strong>{formatDate(row.original.drawDate)}</strong>
					<span>Draw #{row.original.drawNumber}</span>
				</div>
			),
		},
		{
			id: "balls",
			header: "Balls",
			enableSorting: false,
			cell: ({row}) => (
				<div className={styles.resultGroup} aria-label={`Balls for draw ${row.original.drawNumber}`}>
					{getBalls(row.original).map(ball => <BallComponent key={ball} number={ball} className={styles.drawBall}/>) }
				</div>
			),
		},
		{
			id: "stars",
			header: "Stars",
			enableSorting: false,
			cell: ({row}) => (
				<div className={styles.resultGroup} aria-label={`Stars for draw ${row.original.drawNumber}`}>
					{getStars(row.original).map(star => <StarComponent key={star} number={star} className={styles.drawStar}/>) }
				</div>
			),
		},
		{
			id: "jokerPlusNumber",
			header: "Joker+",
			enableSorting: false,
			cell: ({row}) => <span className={styles.additionalGame}>{formatAdditionalGame(row.original.jokerPlusNumber)}</span>,
		},
		{
			id: "myMillionNumber",
			header: "My Million",
			enableSorting: false,
			cell: ({row}) => <span className={styles.additionalGame}>{formatAdditionalGame(row.original.myMillionNumber)}</span>,
		},
		{
			id: "exceptionalEuroMillionsDrawNumber",
			header: "Exceptional",
			enableSorting: false,
			cell: ({row}) => (
				<span className={styles.additionalGame}>{formatAdditionalGame(row.original.exceptionalEuroMillionsDrawNumber)}</span>
			),
		},
	], []);

	const handleSortingChange = (updater: Updater<SortingState>) => {
		setSorting(currentSorting => {
			const nextSorting = typeof updater === "function" ? updater(currentSorting) : updater;
			const drawDateSorting = nextSorting.find(sort => sort.id === "drawDate");

			return [{id: "drawDate", desc: drawDateSorting?.desc ?? DEFAULT_SORTING[0].desc}];
		});
	};

	const table = useReactTable({
		data: draws,
		columns,
		state: {sorting},
		onSortingChange: handleSortingChange,
		enableSortingRemoval: false,
		getCoreRowModel: getCoreRowModel(),
		getSortedRowModel: getSortedRowModel(),
	});

	return (
		<div className={styles.tableShell}>
			<table className={styles.drawsTable}>
				<thead>
					{table.getHeaderGroups().map(headerGroup => (
						<tr key={headerGroup.id}>
							{headerGroup.headers.map(header => {
								const sortDirection = header.column.getIsSorted();
								const sortArrow = sortDirection === "asc" ? "↑" : "↓";
								const sortLabel = sortDirection === "asc" ? "ascending order" : "descending order";

								return (
									<th key={header.id} scope="col">
										{header.column.getCanSort() ? (
											<button className={styles.sortButton} type="button" onClick={header.column.getToggleSortingHandler()}>
												{flexRender(header.column.columnDef.header, header.getContext())}
												<span aria-label={sortLabel}>{sortArrow}</span>
											</button>
										) : flexRender(header.column.columnDef.header, header.getContext())}
									</th>
								);
							})}
						</tr>
					))}
				</thead>
				<tbody>
					{table.getRowModel().rows.map(row => (
						<tr key={row.id}>
							{row.getVisibleCells().map(cell => (
								<td key={cell.id} data-label={String(cell.column.columnDef.header)}>
									{flexRender(cell.column.columnDef.cell, cell.getContext())}
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
