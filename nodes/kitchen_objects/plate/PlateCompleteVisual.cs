using Godot;

public partial class PlateCompleteVisual : Node {


	[Export] private PlateKitchenObject _PlateKitchenObject;
	[Export] public Godot.Collections.Array<KitchenObjectResourceNode3D> _KitchenObjectResourceNode3DList;



	public override void _Ready() {
		_PlateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;

		foreach (KitchenObjectResourceNode3D kitchenObjectResourceNode3D in _KitchenObjectResourceNode3DList) {
			GetNode<Node3D>(kitchenObjectResourceNode3D._NodePath).Hide();
		}
	}

	private void PlateKitchenObject_OnIngredientAdded(KitchenObjectResource kitchenObjectResource) {
		foreach (KitchenObjectResourceNode3D kitchenObjectResourceNode3D in _KitchenObjectResourceNode3DList) {
			if (kitchenObjectResourceNode3D._KitchenObjectResource == kitchenObjectResource) {
				GetNode<Node3D>(kitchenObjectResourceNode3D._NodePath).Show();
			}
		}
	}

}
