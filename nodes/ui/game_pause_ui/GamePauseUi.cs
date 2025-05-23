using Godot;

public partial class GamePauseUi : Control {



	[Export] private Button _ResumeButton;
	[Export] private Button _MainMenuButton;



	public override void _Ready() {
		Hide();

		GamePause.Instance.OnGamePaused += GamePause_OnGamePaused;
		GamePause.Instance.OnGameUnpaused += GamePause_OnGameUnpaused;

		_ResumeButton.Pressed += () => {
			GamePause.Instance.SetPause(false);
		};
		_MainMenuButton.Pressed += () => {
			GamePause.Instance.SetPause(false);
			SceneLoader.Instance.Load(SceneLoader.Instance.MainMenuScenePath);
		};
	}

	public override void _ExitTree() {
		GamePause.Instance.OnGamePaused -= GamePause_OnGamePaused;
		GamePause.Instance.OnGameUnpaused -= GamePause_OnGameUnpaused;
	}

	private void GamePause_OnGamePaused() {
		Show();
	}

	private void GamePause_OnGameUnpaused() {
		Hide();
	}

}
