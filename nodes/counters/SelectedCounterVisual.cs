using Godot;

public partial class SelectedCounterVisual : Node3D {


	[Export] private BaseCounter _Counter;
	// [Export] private Node3D _Visual;


	public override void _Ready() {
		if (Player.Instance != null)
			Player.Instance._Interaction.OnSelectedCounterChanged += PlayerInteraction_OnSelectedCounterChanged;
	}

	private void PlayerInteraction_OnSelectedCounterChanged(BaseCounter selectedCounter) {
		if (selectedCounter == _Counter) {
			Show();
		} else {
			Hide();
		}
	}
}
