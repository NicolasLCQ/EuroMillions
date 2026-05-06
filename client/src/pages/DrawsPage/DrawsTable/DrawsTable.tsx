import {useMemo, useState} from "react";
import {
	flexRender,
	getCoreRowModel,
	getSortedRowModel,
	useReactTable,
	type ColumnDef,
	type SortingState,
} from "@tanstack/react-table";
import {BallComponent, StarComponent} from "shared/components";
import {IDraw} from "shared/types";
import styles from "./DrawsTable.module.css";

interface DrawsTableProps {
	draws: IDraw[];
}

const formatDate = (drawDate: string) => new Intl.DateTimeFormat("fr-FR", {
	day: "2-digit",
	month: "2-digit",
	year: "numeric",
}).format(new Date(drawDate));

const getBalls = (draw: IDraw) => [draw.ball1, draw.ball2, draw.ball3, draw.ball4, draw.ball5];
const getStars = (draw: IDraw) => [draw.star1, draw.star2];

function DrawsTable({draws}: DrawsTableProps) {
	const [sorting, setSorting] = useState<SortingState>([{id: "drawDate", desc: true}]);

	const columns = useMemo<ColumnDef<IDraw>[]>(() => [
		{
			id: "drawDate",
			accessorFn: draw => new Date(draw.drawDate).getTime(),
			header: "Date",
			cell: ({row}) => (
				<div className={styles.dateCell}>
					<strong>{formatDate(row.original.drawDate)}</strong>
					<span>Tirage #{row.original.drawNumber}</span>
				</div>
			),
		},
		{
			id: "balls",
			header: "Boules",
			enableSorting: false,
			cell: ({row}) => (
				<div className={styles.resultGroup} aria-label={`Boules du tirage ${row.original.drawNumber}`}>
					{getBalls(row.original).map(ball => <BallComponent key={ball} number={ball} className={styles.drawBall}/>) }
				</div>
			),
		},
		{
			id: "stars",
			header: "Etoiles",
			enableSorting: false,
			cell: ({row}) => (
				<div className={styles.resultGroup} aria-label={`Etoiles du tirage ${row.original.drawNumber}`}>
					{getStars(row.original).map(star => <StarComponent key={star} number={star} className={styles.drawStar}/>) }
				</div>
			),
		},
	], []);

	const table = useReactTable({
		data: draws,
		columns,
		state: {sorting},
		onSortingChange: setSorting,
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
								const sortLabel = sortDirection === "asc" ? "ancien au recent" : "recent au ancien";

								return (
									<th key={header.id} scope="col">
										{header.column.getCanSort() ? (
											<button className={styles.sortButton} type="button" onClick={header.column.getToggleSortingHandler()}>
												{flexRender(header.column.columnDef.header, header.getContext())}
												<span>{sortLabel}</span>
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
