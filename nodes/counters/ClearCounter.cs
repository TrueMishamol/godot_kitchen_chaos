using Godot;

public partial class ClearCounter : Node3D {


	[Export] public Node3D _CounterTopPoint { get; private set; }
	[Export] private KitchenObjectResource _KitchenObjectResource;

	[Export] private ClearCounter _TmpClearCounterReparent;

	public KitchenObject KitchenObject;



	public void Interact() {
		if (KitchenObject == null) {
			SpawnKitchenObject();
		} else {
			//! TMP
			Reparent();
		}
	}

	private void SpawnKitchenObject() {
		PackedScene packedScene = GD.Load<PackedScene>(_KitchenObjectResource._SceneFilePath);
		KitchenObject kitchenObjectInstance = packedScene.Instantiate<KitchenObject>();

		kitchenObjectInstance.ClearCounter = this;
	}

	private void Reparent() {
		KitchenObject.ClearCounter = _TmpClearCounterReparent;
	}
}
