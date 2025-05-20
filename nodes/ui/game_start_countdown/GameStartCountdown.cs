using Godot;

public partial class GameStartCountdown : RichTextLabel {


	// [Export] private



	public override void _Ready() {
		GameStates.Instance.OnStateChanged += GameStates_OnStateChanged;

		Hide();
	}

	public override void _Process(double delta) {
		if (!GameStates.Instance.IsCountdownToStart)
			return;
			
		Text = "[b]" + Mathf.Ceil(GameStates.Instance.CountdownToStartTimerTime).ToString();
	}

	private void GameStates_OnStateChanged() {
		if (GameStates.Instance.IsCountdownToStart) {
			Show();
		} else {
			Hide();
		}
	}

}
