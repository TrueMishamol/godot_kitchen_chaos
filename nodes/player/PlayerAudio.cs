using Godot;

public partial class PlayerAudio : AudioStreamPlayer3D {


	[Export] private AudioStream _SfxObjectPickup;

	// External
	[Export] private Player _Player;




	public override void _Ready() {
		_Player.OnPickedSomething += () => {
			Stream = _SfxObjectPickup;
			Play();
		};
	}

}
