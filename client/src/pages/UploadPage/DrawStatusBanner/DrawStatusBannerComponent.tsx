import {BannerComponent} from "shared/components";

export interface DrawStatusBannerComponentProps {
	areUpToDate?: boolean;
	isError: boolean;
	isLoading: boolean;
}

function DrawStatusBannerComponent(props: DrawStatusBannerComponentProps) {
	if (props.isLoading) {
		return <BannerComponent state="information">Verification de l'etat des tirages...</BannerComponent>;
	}

	if (props.isError || props.areUpToDate === undefined) {
		return (
			<BannerComponent state="error">
				Impossible de verifier si les tirages sont a jour.
			</BannerComponent>
		);
	}

	if (props.areUpToDate) {
		return <BannerComponent state="success">Les tirages sont a jour.</BannerComponent>;
	}

	return (
		<BannerComponent state="information">
			Les tirages ne sont pas a jour. Ajoutez les derniers fichiers FDJ ou lancez la mise a jour automatique.
		</BannerComponent>
	);
}

export default DrawStatusBannerComponent;
