import {useAllDrawsQuery} from 'api/hooks';
import {PageTitleComponent, TextComponent} from 'shared/components';
import {IDraw} from 'shared/types';
import {DrawsTable} from './DrawsTable';
import styles from './DrawsPage.module.css';

function DrawsPage() {
  const {data, isLoading, isError} = useAllDrawsQuery<IDraw>();

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
