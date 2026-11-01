import {flexRender} from '@tanstack/react-table';
import type {ComponentType, ReactNode} from 'react';

interface TableContentProps<TContext extends object> {
  content: ReactNode | ComponentType<TContext>;
  context: TContext;
}

export function TableContent<TContext extends object>({content, context}: TableContentProps<TContext>) {
  return <>{flexRender(content, context)}</>;
}
