using Godot;

public partial class MainMenu : Control {


	[Export] private Button _PlayButton;
	[Export] private Button _QuitButton;



	public override void _Ready() {
		_PlayButton.Pressed += () => {
			SceneLoader.Instance.Load(SceneLoader.Instance.GameScenePath);
		};
		_QuitButton.Pressed += () => {
			GetTree().Quit();
		};
	}
}

