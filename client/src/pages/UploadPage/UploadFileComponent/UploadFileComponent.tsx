import {BaseDropZoneComponent, ButtonComponents} from 'shared/components';
import {useFiles} from 'shared/hooks';
import type {FileError} from 'react-dropzone';

export interface DropZoneComponentProps {
  className?: string;
  handleSubmitFiles: (files: File[]) => Promise<void>;
}

function UploadFileComponent(props: DropZoneComponentProps) {
  const {files, addFiles, removeFile, clearFiles} = useFiles();

  const noDoubleValidator = (file: File): FileError | null => {
    if (files.some((f) => f.name === file.name)) {
      return {
        code: 'file-already-added',
        message: `${file.name}: already added`,
      };
    }

    return null;
  };

  const submitFiles = async () => {
    await props.handleSubmitFiles(files);
    clearFiles();
  };

  return (
    //todo: Add a shared element for errors, for example: you cannot add the same file twice.
    <div className={props.className}>
      <BaseDropZoneComponent files={files} handleAdd={addFiles} handleDelete={removeFile} validateFile={noDoubleValidator} />
      <ButtonComponents onClick={submitFiles}>Submit</ButtonComponents>
    </div>
  );
}

export default UploadFileComponent;
