using Godot;

[GlobalClass]
public partial class RecipeResource : Resource {

	[Export] public string _Name;
	[Export] public KitchenObjectResource[] _KitchenObjectResourcesList;

}
