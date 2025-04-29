using Godot;

public partial class Interaction : Node {

	// public Player Player { private get; set; }

	[Export] private RayCast3D _Raycast;



	public override void _Process(double delta) {
		HandleInteractions();
	}

	private void HandleInteractions() {
		if (_Raycast.GetCollider() is ClearCounter raycastHit) {
			// GD.Print(raycastHit);
			raycastHit.Interact();
		}

	}


}
