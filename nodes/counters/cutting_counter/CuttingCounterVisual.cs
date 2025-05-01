using Godot;

public partial class CuttingCounterVisual : Node3D {


	private const string CUT = "CuttingCounterCut"; // Animation name
	private const string IDLE = "CuttingCounterIdle"; // Animation name

	// External
	[Export] private CuttingCounter _CuttingCounter;

	// Internal
	[Export] private AnimationPlayer _AnimationPlayer;



	public override void _Ready() {
		_CuttingCounter.OnProgressChanged += ContainerCounter_OnPlayerGrabObject;
		_AnimationPlayer.AnimationFinished += AnimationPlayer_OnAnimationFinished;
	}

	private void ContainerCounter_OnPlayerGrabObject(float progress) {
		if (progress != 0f) {
			_AnimationPlayer.Play(CUT);
		}
	}

	private void AnimationPlayer_OnAnimationFinished(StringName animName) {
		if (animName == CUT) {
			_AnimationPlayer.Play(IDLE);
		}
	}
}
