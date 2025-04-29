using Godot;

public partial class Movement : Node {


	[Export] private float _MaxSpeed = 5.0f;
	[Export] private float _Acceleration = 25.0f;
	[Export] private float _Friction = 20.0f;
	[Export] private float _RotationAcceleration = 10.0f;

	private Player _player;

	private Vector2 _inputDirection = Vector2.Zero;
	private Vector2 _horizontalVelocity = Vector2.Zero;
	private float _verticalVelocity = 0.0f;




	public override void _PhysicsProcess(double delta) {
		if (_player == null)
			return;

		if (!_player.IsMultiplayerAuthority())
			return;

		_inputDirection = Input.GetVector("go_left", "go_right", "go_forward", "go_back").Normalized();
		_horizontalVelocity = new Vector2(_player.Velocity.X, _player.Velocity.Z);
		_verticalVelocity = 0;

		HandleMovement((float)delta);

		_player.Velocity = new Vector3(_horizontalVelocity.X, _verticalVelocity, _horizontalVelocity.Y);
		_player.MoveAndSlide();

		HandleRotation((float)delta);
	}




	public bool IsMoving() {
		return _horizontalVelocity != Vector2.Zero;
	}

	public void SetPlayer(Player player) {
		_player = player;
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
			_player.Rotation = new Vector3(
				_player.Rotation.X,
				Mathf.LerpAngle(_player.Rotation.Y, targetAngle, delta * _RotationAcceleration),
				_player.Rotation.Z
			);
		}
	}
}
