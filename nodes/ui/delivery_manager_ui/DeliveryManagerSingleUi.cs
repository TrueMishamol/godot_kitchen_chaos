using Godot;

public partial class DeliveryManagerSingleUi : Control {


	[Export] private Label _RecipeNameLabel;
	[Export] private Control _IconsContainer;
	[Export] private TextureRect _IconTemplate;



	public override void _Ready() {
		_IconTemplate.Hide();
	}

	public void SetRecipeResource(RecipeResource recipeResource) {
		_RecipeNameLabel.Text = recipeResource._Name;

		foreach (Node child in _IconsContainer.GetChildren()) {
			if (child == _IconTemplate)
				continue;
			child.QueueFree();
		}

		foreach (KitchenObjectResource kitchenObjectResource in recipeResource._KitchenObjectResourcesList) {
			TextureRect templateCopy = (TextureRect)_IconTemplate.Duplicate();
			templateCopy.Show();
			_IconsContainer.AddChild(templateCopy);
			templateCopy.Texture = kitchenObjectResource._Sprite;
		}
	}

}
