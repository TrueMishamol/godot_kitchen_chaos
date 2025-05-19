using Godot;

public partial class StoveCounterAudio : AudioStreamPlayer3D {


	// External
	[Export] private StoveCounter _StoveCounter;

	[Export] private AudioStream _SfxSizzle;



	public override void _Ready() {
		_StoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
	}

	private void StoveCounter_OnStateChanged(StoveCounter.State state) {
		bool playSound = state == StoveCounter.State.Frying || state == StoveCounter.State.Burning;
		if (playSound) {
			if (!(Stream == _SfxSizzle & Playing)) {
				Stream = _SfxSizzle;
				Play();
			}

		} else {
			Stop();
		}
	}


}
