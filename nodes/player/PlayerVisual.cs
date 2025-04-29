using Godot;

public partial class PlayerVisual : Node3D {


	private const string IDLE = "parameters/conditions/idle";
	private const string WALKING = "parameters/conditions/is_walking";

	[Export] private AnimationTree _AnimationTree;

	public Movement PlayerMovement { private get; set; }




	public override void _EnterTree() {
	}


	public override void _Process(double delta) {
		bool isWalking = PlayerMovement.IsWalking;
		_AnimationTree.Set(IDLE, !isWalking);
		_AnimationTree.Set(WALKING, isWalking);
	}

}


