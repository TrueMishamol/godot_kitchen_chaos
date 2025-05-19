using Godot;
using System;

public partial class Player : CharacterBody3D, IKitchenObjectParent {



	public event Action OnPickedSomething;

	public static Player Instance { get; private set; }

	[Export] public Interaction _Interaction { get; private set; }

	[Export] private Movement _Movement;
	[Export] private PlayerVisual _PlayerVisual;
	[Export] public Node3D _HoldingPoint;

	//# IKitchenObjectParent
	public Node3D KitchenObjectHoldingContainer => _HoldingPoint;
	private KitchenObject b_kitchenObject;
	public KitchenObject KitchenObject {
		get => b_kitchenObject;
		set {
			b_kitchenObject = value;
			if (value != null)
				OnPickedSomething?.Invoke();
		}
	}



	public Player() {
		if (Instance != null) {
			GD.PushError("There is more than one Player.Instance");
		}
		Instance = this;

		//# Set Multiplayer Authority
		// if (int.TryParse(Name, out int id)) {
		// 	SetMultiplayerAuthority(id);
		// } else {
		// 	GD.PrintErr($"Failed to parse node name '{Name}' to int for multiplayer authority.");
		// }
	}

	public override void _Ready() {
		if (_Movement != null)
			_Movement.Player = this;

		if (_Interaction != null)
			_Interaction.Player = this;

		if (_PlayerVisual != null)
			_PlayerVisual.PlayerMovement = _Movement;
	}
}
