using Godot;

public partial class GamePlayingClock : Control {



	[Export] private Range _ProgressBar;



	public override void _Process(double delta) {
		_ProgressBar.Value = GameStates.Instance.GamePlayingTimerTimeNormalized;
	}


}
