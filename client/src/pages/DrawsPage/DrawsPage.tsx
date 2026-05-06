import {useQuery} from "@tanstack/react-query";
import {getAllDraws} from "api";
import {API_ROUTES} from "api/client";
import {TextComponent} from "shared/components";
import {PageTitleComponent} from "shared/components/TextComponents/PageTitleComponent";
import {DrawsTable} from "./DrawsTable";
import styles from "./DrawsPage.module.css";

function DrawsPage() {
	const {data, isLoading, isError} = useQuery({
		queryKey: [API_ROUTES.allDraws],
		queryFn: getAllDraws,
	});

	if (isLoading) return <TextComponent>Loading draws...</TextComponent>;
	if (isError) return <TextComponent>Error while loading draws.</TextComponent>;

	const draws = data?.draws ?? [];

	return (
		<div className={styles.drawsPage}>
			<header className={styles.header}>
				<PageTitleComponent>Tirages</PageTitleComponent>
			</header>

			{draws.length === 0 ? <TextComponent>No draw found</TextComponent> : <DrawsTable draws={draws}/>}
		</div>
	);
}

export default DrawsPage;
