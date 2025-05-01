using Godot;

public partial class WorldSpaceProgressBar : Node3D {


	// External
	[Export] private CuttingCounter _CuttingCounter;

	// Internal
	[Export] private ProgressBar _ProgressBar;



	public override void _Ready() {
		_CuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;

		_ProgressBar.Value = 0f;

		Hide();
	}

	private void CuttingCounter_OnProgressChanged(float progress) {
		_ProgressBar.Value = progress;

		if (progress == 0f || progress == 1f) {
			Hide();
		} else {
			Show();
		}
	}
}
