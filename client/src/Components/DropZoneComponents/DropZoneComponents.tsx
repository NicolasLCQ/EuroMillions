import {useDropzone} from 'react-dropzone';
import "./DropZoneComponents.css";

export default function DropZoneComponents(){
	const {getRootProps, getInputProps, isDragActive} = useDropzone()

	return (

		<div className="DropZone" {...getRootProps()}>
			<input {...getInputProps()} />
			{
				isDragActive ?
					<p>Drop the files here ...</p> :
					<p>Drag 'n' drop some files here, or click to select files</p>
			}
		</div>
	)
}