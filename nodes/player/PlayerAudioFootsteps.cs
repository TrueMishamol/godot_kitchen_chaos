using Godot;

public partial class PlayerAudioFootsteps : AudioStreamPlayer3D {


	// External
	[Export] private Movement _Movement;

	[Export] private Timer _Timer;



	public override void _Ready() {
		_Timer.Timeout += Timer_OnTimeout;
	}

	private void Timer_OnTimeout() {
		if (_Movement.IsWalking) {
			Play();
		}
	}

}
