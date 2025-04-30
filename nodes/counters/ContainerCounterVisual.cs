using Godot;

public partial class ContainerCounterVisual : Node3D {


	private const string OPEN_CLOSE = "ContainerOpenClose"; // Animation name

	// External
	[Export] private ContainerCounter _ContainerCounter;

	[Export] private AnimationPlayer _AnimationPlayer;


	public override void _Ready() {
		_ContainerCounter.OnPlayerGrabObject += ContainerCounter_OnPlayerGrabObject;
	}

	private void ContainerCounter_OnPlayerGrabObject() {
		_AnimationPlayer.Play(OPEN_CLOSE);
	}

}
