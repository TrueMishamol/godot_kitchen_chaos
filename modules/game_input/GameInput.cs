using Godot;
using System;

public partial class GameInput : Node {


	public static event Action OnInteractPressed;
	public static event Action OnInteractAlternatePressed;


	private const string GO_LEFT = "go_left";
	private const string GO_RIGHT = "go_right";
	private const string GO_FORWARD = "go_forward";
	private const string GO_BACK = "go_back";

	private const string INTERACT = "interact";
	private const string INTERACT_ALTERNATE = "interact_alternate";





	public static Vector2 GetMovementVectorNormalized() {
		return Input.GetVector(GO_LEFT, GO_RIGHT, GO_FORWARD, GO_BACK).Normalized();
	}

	public override void _Input(InputEvent @event) {
		if (@event.IsActionPressed(INTERACT)) {
			OnInteractPressed?.Invoke();
		}
		if (@event.IsActionPressed(INTERACT_ALTERNATE)) {
			OnInteractAlternatePressed?.Invoke();
		}
	}

}
