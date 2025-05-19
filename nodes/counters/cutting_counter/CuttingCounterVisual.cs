using Godot;

public partial class CuttingCounterVisual : Node3D {


	private const string CUT = "CuttingCounterCut"; // Animation name
	private const string IDLE = "CuttingCounterIdle"; // Animation name

	// External
	[Export] private CuttingCounter _CuttingCounter;

	// Internal
	[Export] private AnimationPlayer _AnimationPlayer;



	public override void _Ready() {
		_CuttingCounter.OnCut += ContainerCounter_OnCut;
		_AnimationPlayer.AnimationFinished += AnimationPlayer_OnAnimationFinished;
	}

	private void ContainerCounter_OnCut() {
		_AnimationPlayer.Play(CUT);
	}

	private void AnimationPlayer_OnAnimationFinished(StringName animName) {
		if (animName == CUT) {
			_AnimationPlayer.Play(IDLE);
		}
	}
}
