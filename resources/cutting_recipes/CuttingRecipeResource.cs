using Godot;

[GlobalClass]
public partial class CuttingRecipeResource : Resource {

	[Export] public KitchenObjectResource _Input;
	[Export] public KitchenObjectResource _Output;

}
