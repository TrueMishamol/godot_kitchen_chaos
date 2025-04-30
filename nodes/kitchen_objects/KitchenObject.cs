using Godot;

public partial class KitchenObject : Node3D {


	[Export] public KitchenObjectResource _KitchenObjectResource { get; private set; }

	private ClearCounter f_clearCounter;
	public ClearCounter ClearCounter {
		get {
			return f_clearCounter;
		}
		set {
			if (value.KitchenObject != null) {
				GD.PushError("Counter already has a KitchenObject");
				return;
			}
			SetClearCounter(value);
			f_clearCounter = value;
		}
	}




	private void SetClearCounter(ClearCounter newClearCounter) {
		if (f_clearCounter != null) {
			f_clearCounter.KitchenObject = null;
		}

		// Reparent
		Node3D currentParent = GetParent() as Node3D;
		if (currentParent != null)
			currentParent.RemoveChild(this);
		newClearCounter._CounterTopPoint.AddChild(this);

		newClearCounter.KitchenObject = this;
	}

}
