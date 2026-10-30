import tsParser from '@typescript-eslint/parser';
import tsPlugin from '@typescript-eslint/eslint-plugin';
import reactHooks from 'eslint-plugin-react-hooks';
import reactRefresh from 'eslint-plugin-react-refresh';

const publicApiPatterns = ['@/app/**', '@/pages/*/**', '@/widgets/*/**', '@/features/*/**', '@/entities/*/**', '@/shared/*/*/**'];

const fsdImportRule = (forbiddenLayers = []) => [
  'error',
  {
    patterns: [
      {
        group: publicApiPatterns,
        message: 'Import this module through its public API.',
      },
      ...(forbiddenLayers.length > 0
        ? [
            {
              group: forbiddenLayers.flatMap((layer) => [`@/${layer}`, `@/${layer}/**`]),
              message: 'This dependency violates the FSD layer direction or slice isolation.',
            },
          ]
        : []),
    ],
  },
];

export default [
  {
    ignores: ['dist'],
  },
  {
    files: ['**/*.{ts,tsx}'],
    languageOptions: {
      parser: tsParser,
      ecmaVersion: 'latest',
      sourceType: 'module',
    },
    plugins: {
      '@typescript-eslint': tsPlugin,
      'react-hooks': reactHooks,
      'react-refresh': reactRefresh,
    },
    rules: {
      ...tsPlugin.configs.recommended.rules,
      ...reactHooks.configs.recommended.rules,
      'react-refresh/only-export-components': ['warn', {allowConstantExport: true}],
      'no-restricted-imports': fsdImportRule(),
    },
  },
  {
    files: ['src/shared/**/*.{ts,tsx}'],
    rules: {
      'no-restricted-imports': fsdImportRule(['app', 'pages', 'widgets', 'features', 'entities']),
    },
  },
  {
    files: ['src/entities/**/*.{ts,tsx}'],
    rules: {
      'no-restricted-imports': fsdImportRule(['app', 'pages', 'widgets', 'features', 'entities']),
    },
  },
  {
    files: ['src/features/**/*.{ts,tsx}'],
    rules: {
      'no-restricted-imports': fsdImportRule(['app', 'pages', 'widgets', 'features']),
    },
  },
  {
    files: ['src/widgets/**/*.{ts,tsx}'],
    rules: {
      'no-restricted-imports': fsdImportRule(['app', 'pages', 'widgets']),
    },
  },
  {
    files: ['src/pages/**/*.{ts,tsx}'],
    rules: {
      'no-restricted-imports': fsdImportRule(['app', 'pages']),
    },
  },
];
