using Godot;

public partial class StoveCounterVisual : Node3D {


	// External
	[Export] private StoveCounter _StoveCounter;

	// Internal
	[Export] private Node3D[] _StoveOnVisualNodes;



	public override void _Ready() {
		_StoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
	}

	private void StoveCounter_OnStateChanged(StoveCounter.State state) {
		bool showVisual = state == StoveCounter.State.Frying || state == StoveCounter.State.Burning;

		if (showVisual)
			foreach (Node3D node in _StoveOnVisualNodes) {
				node.Show();
			}
		else
			foreach (Node3D node in _StoveOnVisualNodes) {
				node.Hide();
			}
	}
}
