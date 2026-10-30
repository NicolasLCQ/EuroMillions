import {QueryClientProvider} from '@tanstack/react-query';
import queryClient from './QueryClient';
import type {ReactNode} from 'react';

export interface IQueryProviderProps {
  children: ReactNode;
}

const QueryProvider = ({children}: IQueryProviderProps) => {
  return <QueryClientProvider client={queryClient}>{children}</QueryClientProvider>;
};

export default QueryProvider;
