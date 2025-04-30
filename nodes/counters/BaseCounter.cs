using Godot;

public partial class BaseCounter : Node3D, IKitchenObjectParent {


	[Export] public Node3D _CounterTopPoint;

	//# IKitchenObjectParent
	public Node3D KitchenObjectHoldingContainer => _CounterTopPoint;
	public KitchenObject KitchenObject { get; set; }




	public virtual void Interact(Player player) {

	}

}
