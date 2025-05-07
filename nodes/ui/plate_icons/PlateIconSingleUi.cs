using Godot;

public partial class PlateIconSingleUi : Control {


	[Export] private TextureRect _TextureRect;



	public void SetKitchenObjectResource(KitchenObjectResource kitchenObjectResource) {
		_TextureRect.Texture = kitchenObjectResource._Sprite;
	}

}
