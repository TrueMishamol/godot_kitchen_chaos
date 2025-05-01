using Godot;

public partial class ContainerCounterVisual : Node3D {


	private const string OPEN_CLOSE = "ContainerOpenClose"; // Animation name

	// External
	[Export] private ContainerCounter _ContainerCounter;

	// Internal
	[Export] private AnimationPlayer _AnimationPlayer;
	[Export] private Sprite3D _ObjectSprite;



	public override void _Ready() {
		_ContainerCounter.OnPlayerGrabObject += ContainerCounter_OnPlayerGrabObject;

		_ObjectSprite.Texture = _ContainerCounter._KitchenObjectResource._Sprite;
	}

	private void ContainerCounter_OnPlayerGrabObject() {
		_AnimationPlayer.Play(OPEN_CLOSE);
	}
}
