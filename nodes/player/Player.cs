using Godot;

public partial class Player : CharacterBody3D {



	[Export] private Movement _Movement;
	[Export] private PlayerVisual _PlayerVisual;




	public override void _EnterTree() {
		//# Set Multiplayer Authority
		// if (int.TryParse(Name, out int id)) {
		// 	SetMultiplayerAuthority(id);
		// } else {
		// 	GD.PrintErr($"Failed to parse node name '{Name}' to int for multiplayer authority.");
		// }
	}

	public override void _Ready() {
		_Movement.Player = this;
		_PlayerVisual.PlayerMovement = _Movement;
	}
}
