using Godot;

public partial class DeliveryManagerUi : MarginContainer {


	[Export] private Control _Container;
	[Export] private Control _RecipeTemplate;



	public override void _Ready() {
		_RecipeTemplate.Hide();
		UpdateVisual();

		DeliveryManager.Instance.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
		DeliveryManager.Instance.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted;
	}

	private void DeliveryManager_OnRecipeSpawned() {
		UpdateVisual();
	}

	private void DeliveryManager_OnRecipeCompleted() {
		UpdateVisual();
	}




	private void UpdateVisual() {
		foreach (Node child in _Container.GetChildren()) {
			if (child == _RecipeTemplate)
				continue;
			child.QueueFree();
		}

		foreach (RecipeResource recipeResource in DeliveryManager.Instance.WaitingRecipeResourcesList) {
			DeliveryManagerSingleUi templateCopy = (DeliveryManagerSingleUi)_RecipeTemplate.Duplicate();
			templateCopy.Show();
			_Container.AddChild(templateCopy);
			templateCopy.SetRecipeResource(recipeResource);
		}
	}
}
