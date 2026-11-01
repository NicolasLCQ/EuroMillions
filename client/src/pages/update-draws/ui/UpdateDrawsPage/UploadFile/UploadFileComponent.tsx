import {ButtonComponents} from '@/shared/ui/button';
import {BaseDropZoneComponent, type DropZoneComponentsProps} from '@/shared/ui/drop-zone';

export interface UploadFileComponentProps extends DropZoneComponentsProps {
  handleSubmitFiles: () => Promise<void>;
}

function UploadFileComponent({handleSubmitFiles, ...dropZoneProps}: UploadFileComponentProps) {
  return (
    <div className={dropZoneProps.className}>
      <BaseDropZoneComponent
        files={dropZoneProps.files}
        handleAdd={dropZoneProps.handleAdd}
        handleDelete={dropZoneProps.handleDelete}
        validateFile={dropZoneProps.validateFile}
      />
      <ButtonComponents onClick={handleSubmitFiles}>Submit</ButtonComponents>
    </div>
  );
}

export default UploadFileComponent;
