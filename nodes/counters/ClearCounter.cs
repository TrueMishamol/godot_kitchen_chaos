using Godot;

public partial class ClearCounter : Node3D, IKitchenObjectParent {


	[Export] public Node3D _CounterTopPoint;
	[Export] private KitchenObjectResource _KitchenObjectResource;

	//# IKitchenObjectParent
	public Node3D KitchenObjectHoldingContainer => _CounterTopPoint;
	public KitchenObject KitchenObject { get; set; }




	public void Interact(Player player) {
		if (KitchenObject == null) {
			SpawnKitchenObject();
		} else {
			KitchenObject.KitchenObjectParent = player;
		}
	}

	private void SpawnKitchenObject() {
		PackedScene packedScene = GD.Load<PackedScene>(_KitchenObjectResource._SceneFilePath);
		KitchenObject kitchenObjectInstance = packedScene.Instantiate<KitchenObject>();

		kitchenObjectInstance.KitchenObjectParent = this;
	}
}
