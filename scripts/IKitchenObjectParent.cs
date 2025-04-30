using Godot;

public interface IKitchenObjectParent {


	public Node3D KitchenObjectHoldingContainer { get; }
	public KitchenObject KitchenObject { get; set; }



	// public Node3D GetKitchenObjectFollowTransform();

	// public void SetKitchenObject(KitchenObject kitchenObject);

	// public KitchenObject GetKitchenObject();

	// public void ClearKitchenObject();

	// public bool HasKitchenObject();
}
