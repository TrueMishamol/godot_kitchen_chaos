using Godot;

[GlobalClass]
public partial class FryingRecipeResource : Resource {

	[Export] public KitchenObjectResource _Input;
	[Export] public KitchenObjectResource _Output;
	[Export] public float _FryingTimerMax = 3.0f;
}
