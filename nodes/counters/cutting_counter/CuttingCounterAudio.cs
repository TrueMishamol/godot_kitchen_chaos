using Godot;

public partial class CuttingCounterAudio : BaseCounterAudio {


	// External
	[Export] private CuttingCounter _CuttingCounter;

	[Export] private AudioStream _SfxChop;



	public override void _Ready() {
		base._Ready();

		_CuttingCounter.OnCut += () => {
			Stream = _SfxChop;
			Play();
		};
	}

}
