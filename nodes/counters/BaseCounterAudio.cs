using Godot;

public partial class BaseCounterAudio : AudioStreamPlayer3D {


	// External
	[Export] protected BaseCounter _Counter;

	[Export] protected AudioStream _SfxObjectDrop;



	public override void _Ready() {
		_Counter.OnObjectDrop += () => {
			Stream = _SfxObjectDrop;
			Play();
		};
	}
}
