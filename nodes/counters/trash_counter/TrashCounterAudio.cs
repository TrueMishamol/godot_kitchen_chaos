using Godot;

public partial class TrashCounterAudio : BaseCounterAudio {


	// External
	[Export] private TrashCounter _TrashCounter;

	[Export] private AudioStream _SfxTrash;



	public override void _Ready() {
		base._Ready();

		_TrashCounter.OnTrash += () => {
			Stream = _SfxTrash;
			Play();
		};
	}
}
