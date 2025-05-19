using Godot;
using System;

public partial class BaseCounter : Node3D, IKitchenObjectParent {


	public event Action OnObjectDrop;

	[Export] public Node3D _CounterTopPoint;

	//# IKitchenObjectParent
	public Node3D KitchenObjectHoldingContainer => _CounterTopPoint;
	private KitchenObject b_kitchenObject;
	public KitchenObject KitchenObject {
		get => b_kitchenObject;
		set {
			b_kitchenObject = value;
			if (value != null) {
				// OnObjectDrop?.Invoke(); //! not here
			}
		}
	}



	public virtual void Interact(Player player) {

	}

	public virtual void InteractAlternate(Player player) {

	}

	protected void InvokeOnObjectDrop() {
		OnObjectDrop?.Invoke();
	}

}
