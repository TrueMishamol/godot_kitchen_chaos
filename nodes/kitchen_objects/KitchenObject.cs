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
