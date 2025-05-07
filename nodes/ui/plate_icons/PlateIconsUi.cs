using Godot;

public partial class PlateIconsUi : Node3D {


	// External
	[Export] private PlateKitchenObject _PlateKitchenObject;

	// Internal
	[Export] private Control _IconsContainer;
	[Export] private Control _IconTemplate;




	public override void _EnterTree() {
		_IconTemplate.Hide();
	}

	public override void _Ready() {
		_PlateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
	}

	private void PlateKitchenObject_OnIngredientAdded(KitchenObjectResource kitchenObjectResource) {
		UpdateVisual();
	}

	private void UpdateVisual() {

		foreach (Node child in _IconsContainer.GetChildren()) {
			if (child == _IconTemplate) //! May delete it 'cause it is not just Node but Control
				continue;
			child.QueueFree();
		}

		foreach (KitchenObjectResource kitchenObjectResource in _PlateKitchenObject.KitchenObjectResourcesList) {
			PlateIconSingleUi iconCopy = (PlateIconSingleUi)_IconTemplate.Duplicate();
			iconCopy.Show();
			_IconsContainer.AddChild(iconCopy);
			iconCopy.SetKitchenObjectResource(kitchenObjectResource);
		}
	}

}
