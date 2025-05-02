using Godot;

public partial class WorldSpaceProgressBar : Node3D {


	// External
	[Export] private Node _IHasProgress;
	private IHasProgress _hasProgress;

	// Internal
	[Export] private ProgressBar _ProgressBar;



	public override void _Ready() {
		if (_IHasProgress is IHasProgress _hasProgress) {
			_hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;
		} else {
			GD.PushError(nameof(_IHasProgress) + " Doesn't have script " + nameof(IHasProgress));
		}

		_ProgressBar.Value = 0f;

		Hide();
	}

	private void HasProgress_OnProgressChanged(float progress) {
		_ProgressBar.Value = progress;

		if (progress == 0f || progress == 1f) {
			Hide();
		} else {
			Show();
		}
	}
}
