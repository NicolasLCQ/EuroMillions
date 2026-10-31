import {useAllDrawsQuery} from '../api/useAllDrawsQuery';
import {PageTitleComponent} from '@/shared/ui/page-title';
import {TextComponent} from '@/shared/ui/text';
import DrawsTable from './DrawsTable/DrawsTable';
import styles from './DrawsPage.module.css';

function DrawsPage() {
  const {data, isLoading, isError} = useAllDrawsQuery();

  if (isLoading) return <TextComponent>Loading draws...</TextComponent>;
  if (isError) return <TextComponent>Error while loading draws.</TextComponent>;

  const draws = data?.draws ?? [];

  return (
    <div className={styles.drawsPage}>
      <header className={styles.header}>
        <PageTitleComponent>Draws</PageTitleComponent>
      </header>

      {draws.length === 0 ? <TextComponent>No draw found</TextComponent> : <DrawsTable draws={draws} />}
    </div>
  );
}

export default DrawsPage;
