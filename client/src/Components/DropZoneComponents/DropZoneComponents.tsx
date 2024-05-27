import {useDropzone} from 'react-dropzone';
import "./DropZoneComponents.css";

export default function DropZoneComponents(){
	const {acceptedFiles, getRootProps, getInputProps, isDragActive} = useDropzone({accept: {'csv': []}})

	const files = acceptedFiles.map(file => (
		<li key={file.name}>
			{file.name} - {file.size} bytes
		</li>
	));

	return (
		<div className="DropZone" {...getRootProps()}>
			<input {...getInputProps()} />
			{
				isDragActive ?
					<p>Drop the files here ...</p> :
					<p>Drag 'n' drop some files here, or click to select files</p>
			}
			<aside>
				<ul>{files}</ul>
			</aside>
		</div>
	)
}