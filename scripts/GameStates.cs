using Godot;
using System;

public partial class GameStates : Node {



	public static GameStates Instance { get; private set; }

	public event Action OnStateChanged;

	[Export] private Timer _WaitingToStartTimer;
	[Export] private Timer _CountdownToStartTimer;
	[Export] private Timer _GamePlayingTimer;


	private enum State {
		WaitingToStart,
		CountdownToStart,
		GamePlaying,
		GameOver,
	}

	public bool IsCountdownToStart => _state == State.CountdownToStart;
	public bool IsGamePlaying => _state == State.GamePlaying;
	public bool IsGameOver => _state == State.GameOver;
	public float CountdownToStartTimerTime {
		get {
			if (_CountdownToStartTimer != null)
				return (float)_CountdownToStartTimer.TimeLeft;
			else
				return 0f;
		}
	}
	public float GamePlayingTimerTimeNormalized {
		get {
			if (_GamePlayingTimer != null)
				return 1 - (float)(_GamePlayingTimer.TimeLeft / _GamePlayingTimer.WaitTime);
			else
				return 0f;
		}
	}

	private State b_state = State.WaitingToStart;
	private State _state {
		get => b_state;
		set {
			b_state = value;
			UpdateStateChanged();
		}
	}



	public override void _EnterTree() {
		Instance = this;
	}

	public override void _Ready() {
		UpdateStateChanged();
	}

	private void UpdateStateChanged() {
		switch (_state) {
			case State.WaitingToStart:
				_WaitingToStartTimer.Start();
				_WaitingToStartTimer.Timeout += () => {
					_state = State.CountdownToStart;
					// _WaitingToStartTimer.QueueFree();
					OnStateChanged?.Invoke();
				};
				break;
			case State.CountdownToStart:
				_CountdownToStartTimer.Start();
				_CountdownToStartTimer.Timeout += () => {
					_state = State.GamePlaying;
					// _CountdownToStartTimer.QueueFree();
					OnStateChanged?.Invoke();
				};
				break;
			case State.GamePlaying:
				_GamePlayingTimer.Start();
				_GamePlayingTimer.Timeout += () => {
					_state = State.GameOver;
					// _GamePlayingTimer.QueueFree();
					OnStateChanged?.Invoke();
				};
				break;
			case State.GameOver:
				break;
		}

		GD.Print(_state);
	}

}
