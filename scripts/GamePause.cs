using Godot;
using System;

public partial class GamePause : Node {


	public static GamePause Instance;

	public event Action OnGamePaused;
	public event Action OnGameUnpaused;

	private bool isGamePaused = false;



	public override void _EnterTree() {
		Instance = this;
	}

	public override void _Ready() {
		GameInput.OnPausePressed += GameInput_OnPausePressed;
	}

	private void GameInput_OnPausePressed() {
		TogglePause();
	}

	public void TogglePause() {
		SetPause(!isGamePaused);
	}

	public void SetPause(bool isPaused) {
		isGamePaused = isPaused;
		GetTree().Paused = isPaused;

		if (isPaused) {
			OnGamePaused?.Invoke();
		} else {
			OnGameUnpaused?.Invoke();
		}
	}

	public override void _ExitTree() {
		GameInput.OnPausePressed -= GameInput_OnPausePressed;
	}
}
