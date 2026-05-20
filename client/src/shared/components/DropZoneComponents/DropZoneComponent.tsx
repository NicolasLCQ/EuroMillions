import styles from './DropZoneComponent.module.css';
import {type FileError, useDropzone} from 'react-dropzone';
import {FileComponent} from './FileComponents';
import React from 'react';

interface DropZoneComponentsProps {
  className?: string;
  files: File[];
  handleAdd: (files: File[]) => void;
  handleDelete: (file: File) => void;
  validateFile?: (file: File) => FileError | readonly FileError[] | null;
}

const DropZoneComponent: React.FC<DropZoneComponentsProps> = ({
  className,
  files,
  handleAdd,
  handleDelete,
  validateFile,
}: DropZoneComponentsProps) => {
  const {getRootProps, getInputProps} = useDropzone({
    accept: {
      'text/csv': ['.csv'],
    },
    onDrop: (files) => handleAdd(files),
    validator: validateFile,
  });

  const dragInformationsItem = <p className={styles.dragInformation}>Drag 'n' drop some files here, or click to select files</p>;

  const fileListItem = (
    <aside className={styles.fileListSection}>
      {files.map((file) => (
        <FileComponent file={file} handleDelete={handleDelete} key={file.name} />
      ))}
    </aside>
  );

  return (
    <div className={className ? `${styles.dropZone} ${className}` : styles.dropZone}>
      <div {...getRootProps({className: styles.dropZoneSection})}>
        <input {...getInputProps()} />
        {dragInformationsItem}
      </div>
      {files?.length > 0 && fileListItem}
    </div>
  );
};

export default DropZoneComponent;
