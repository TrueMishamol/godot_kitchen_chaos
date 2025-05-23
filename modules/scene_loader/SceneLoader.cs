using Godot;

public partial class SceneLoader : Node {


	public static SceneLoader Instance { get; private set; }

	[Export(PropertyHint.File, "*.tscn,*.scn")] public string MainMenuScenePath;
	[Export(PropertyHint.File, "*.tscn,*.scn")] public string GameScenePath;
	[Export(PropertyHint.File, "*.tscn,*.scn")] public string LoadingScenePath;

	private static string _targetScenePath;
	private static Node _newScene;



	public override void _EnterTree() {
		Instance = this;
	}

	public void Load(string scenePath) {
		_targetScenePath = scenePath;
		GetTree().ChangeSceneToFile(_targetScenePath);


		// _targetScenePath = scenePath;

		// PackedScene packedScene = GD.Load<PackedScene>(LoadingScenePath);
		// if (packedScene == null) {
		// 	GD.PushError($"Failed to load scene");
		// 	return;
		// }

		// _newScene = packedScene.Instantiate();
		// _newScene.Ready += InitializeScene;
		// GetTree().Root.AddChild(_newScene);
	}

	// private void InitializeScene() {
	// 	GetTree().ChangeSceneToFile(_targetScenePath);
	// 	_newScene.Ready -= InitializeScene;
	// 	_newScene.QueueFree();
	// }
}