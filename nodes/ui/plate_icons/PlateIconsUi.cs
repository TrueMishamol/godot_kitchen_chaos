using Godot;

public partial class PlateIconsUi : Node3D {


	// External
	[Export] private PlateKitchenObject _PlateKitchenObject;

	// Internal
	[Export] private Control _IconsContainer;
	[Export] private Control _IconTemplate;



	public override void _Ready() {
		_IconTemplate.Hide();

		_PlateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
	}

	private void PlateKitchenObject_OnIngredientAdded(KitchenObjectResource kitchenObjectResource) {
		UpdateVisual();
	}

	private void UpdateVisual() {
		foreach (Node child in _IconsContainer.GetChildren()) {
			if (child == _IconTemplate)
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
