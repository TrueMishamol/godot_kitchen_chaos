using Godot;
using System;

public partial class GameInput : Node {


	public static event Action OnInteractPressed;


	private const string GO_LEFT = "go_left";
	private const string GO_RIGHT = "go_right";
	private const string GO_FORWARD = "go_forward";
	private const string GO_BACK = "go_back";

	private const string INTERACT = "interact";





	public static Vector2 GetMovementVectorNormalized() {
		return Input.GetVector("go_left", "go_right", "go_forward", "go_back").Normalized();
	}

	public override void _Input(InputEvent @event) {
		if (@event.IsActionPressed(INTERACT)) {
			OnInteractPressed?.Invoke();
		}
	}

}
