using Godot;

public partial class Movement : Node {


	[Export] private float _MaxSpeed = 5.0f;
	[Export] private float _Acceleration = 25.0f;
	[Export] private float _Friction = 20.0f;
	[Export] private float _RotationAcceleration = 10.0f;

	public Player Player { private get; set; }
	public bool IsWalking => _inputDirection != Vector2.Zero;
	// public bool IsMoving => _horizontalVelocity != Vector2.Zero;

	private Vector2 _inputDirection = Vector2.Zero;
	private Vector2 _horizontalVelocity = Vector2.Zero;
	private float _verticalVelocity = 0.0f;




	public override void _PhysicsProcess(double delta) {
		if (Player == null)
			return;

		if (!Player.IsMultiplayerAuthority())
			return;

		// _inputDirection = Input.GetVector("go_left", "go_right", "go_forward", "go_back").Normalized();
		_inputDirection = GameInput.GetMovementVectorNormalized();
		_horizontalVelocity = new Vector2(Player.Velocity.X, Player.Velocity.Z);
		_verticalVelocity = 0;

		HandleMovement((float)delta);

		Player.Velocity = new Vector3(_horizontalVelocity.X, _verticalVelocity, _horizontalVelocity.Y);
		Player.MoveAndSlide();

		HandleRotation((float)delta);
	}




	private void HandleMovement(float delta) {
		if (_inputDirection == Vector2.Zero) {
			//# Apply friction (slow down)
			if (_horizontalVelocity.Length() > (_Friction * delta)) {
				_horizontalVelocity -= _horizontalVelocity.Normalized() * (_Friction * delta);
			} else {
				_horizontalVelocity = Vector2.Zero;
			}
		} else {
			//# Accelerate
			_horizontalVelocity += _inputDirection * _Acceleration * delta;
			_horizontalVelocity = _horizontalVelocity.LimitLength(_MaxSpeed);
		}
	}

	private void HandleRotation(float delta) {
		if (_inputDirection != Vector2.Zero) {
			float targetAngle = Mathf.Atan2(_inputDirection.X * 100f, _inputDirection.Y * 100f);
			Player.Rotation = new Vector3(
				Player.Rotation.X,
				Mathf.LerpAngle(Player.Rotation.Y, targetAngle, delta * _RotationAcceleration),
				Player.Rotation.Z
			);
		}
	}
}
