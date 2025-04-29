using Godot;

public partial class CameraFollow : Node {


	[Export] private Camera3D _Camera;
	[Export] private Node3D _Target;

	[Export] private float _Distance = 21.0f;
	[Export] private float _Height = 21.0f;
	[Export] private float _LerpWeight = 0.04f;



	public override void _Ready() {
		if (_Camera == null)
			_Camera = GetParent<Camera3D>();
	}

	public override void _PhysicsProcess(double delta) {
		if (_Target == null)
			return;

		Vector3 targetPosition = _Target.GlobalTransform.Origin;
		Vector3 offset = new Vector3(0, _Height, _Distance);
		Vector3 currentPos = _Camera.GlobalTransform.Origin;

		// Smoothly interpolate camera position towards target + offset
		Vector3 newPos = currentPos.Lerp(targetPosition + offset, _LerpWeight);
		_Camera.GlobalTransform = new Transform3D(_Camera.GlobalTransform.Basis, newPos);

		// Make camera look at the target position
		_Camera.LookAt(targetPosition);
	}
}
