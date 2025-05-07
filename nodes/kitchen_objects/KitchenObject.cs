using Godot;

public partial class KitchenObject : Node3D {


	[Export] public KitchenObjectResource _KitchenObjectResource { get; private set; }

	private IKitchenObjectParent f_kitchenObjectParent;
	public IKitchenObjectParent KitchenObjectParent {
		get => f_kitchenObjectParent;
		set {
			if (value.KitchenObject != null) {
				GD.PushError(nameof(IKitchenObjectParent) + " already has a KitchenObject");
				return;
			}
			SetKitchenObjectParent(value);
			f_kitchenObjectParent = value;
		}
	}




	public static KitchenObject SpawnKitchenObject(KitchenObjectResource kitchenObjectResource, IKitchenObjectParent kitchenObjectParent) {
		// Spawn new Kitchen Object
		PackedScene packedScene = GD.Load<PackedScene>(kitchenObjectResource._SceneFilePath);
		KitchenObject kitchenObjectInstance = packedScene.Instantiate<KitchenObject>();

		// Give it to a player or counter
		kitchenObjectInstance.KitchenObjectParent = kitchenObjectParent;

		// Return Kitchen Object
		return kitchenObjectInstance;
	}



	public bool TryGetPlate(out PlateKitchenObject plateKitchenObject) {
		if (this is PlateKitchenObject) {
			plateKitchenObject = this as PlateKitchenObject;
			return true;
		} else {
			plateKitchenObject = null;
			return false;
		}
	}



	public void DestroySelf() {
		KitchenObjectParent.KitchenObject = null;

		QueueFree();
	}

	private void SetKitchenObjectParent(IKitchenObjectParent newKitchenObjectParent) {
		if (f_kitchenObjectParent != null) {
			f_kitchenObjectParent.KitchenObject = null;
		}

		// Reparent
		Node3D currentParent = GetParent() as Node3D;
		if (currentParent != null)
			currentParent.RemoveChild(this);
		newKitchenObjectParent.KitchenObjectHoldingContainer.AddChild(this);

		newKitchenObjectParent.KitchenObject = this;
	}

}
