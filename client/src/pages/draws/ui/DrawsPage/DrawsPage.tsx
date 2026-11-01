import {useDrawsTable} from '../../model/useDrawsTable';
import {drawsColumns} from './DrawsTable/drawsColumns';
import {useDraws} from '../../model/useDraws';
import {PageTitleComponent} from '@/shared/ui/page-title';
import {TextComponent} from '@/shared/ui/text';
import DrawsTable from './DrawsTable/DrawsTable';
import styles from './DrawsPage.module.css';

function DrawsPage() {
  const {draws, isLoading, isError} = useDraws();
  const table = useDrawsTable(draws, drawsColumns);

  if (isLoading) return <TextComponent>Loading draws...</TextComponent>;
  if (isError) return <TextComponent>Error while loading draws.</TextComponent>;

  return (
    <div className={styles.drawsPage}>
      <header className={styles.header}>
        <PageTitleComponent>Draws</PageTitleComponent>
      </header>

      {draws.length === 0 ? <TextComponent>No draw found</TextComponent> : <DrawsTable table={table} />}
    </div>
  );
}

export default DrawsPage;
