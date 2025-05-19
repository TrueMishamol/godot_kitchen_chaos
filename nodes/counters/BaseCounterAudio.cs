using Godot;

public partial class BaseCounterAudio : AudioStreamPlayer3D {


	// External
	[Export] protected BaseCounter _Counter;

	[Export] protected AudioStream _SfxObjectDrop;



	public override void _Ready() {
		GD.Print(_Counter.GetPath());
		if (_Counter == null) {
			// GD.PushError(this);
			return;
		}
		_Counter.OnObjectDrop += () => {
			Stream = _SfxObjectDrop;
			Play();
		};
	}
}
