using Godot;

public partial class SelectedCounterVisual : Node3D {


	[Export] private ClearCounter _ClearCounter;
	// [Export] private Node3D _Visual;


	public override void _Ready() {
		Player.Instance._Interaction.OnSelectedCounterChanged += PlayerInteraction_OnSelectedCounterChanged;
	}

	private void PlayerInteraction_OnSelectedCounterChanged(ClearCounter selectedClearCounter) {
		if (selectedClearCounter == _ClearCounter) {
			Show();
		} else {
			Hide();
		}
	}
}
