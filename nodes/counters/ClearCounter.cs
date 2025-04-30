using Godot;

public partial class ClearCounter : Node3D {


	[Export] private Node3D _CounterTopPoint;
	[Export] private KitchenObjectResource _KitchenObjectResource;



	public void Interact() {
		GD.Print(this);

		PackedScene packedScene = GD.Load<PackedScene>(_KitchenObjectResource._SceneFilePath);
		Node3D kitchenObjectInstance = packedScene.Instantiate<Node3D>();
		_CounterTopPoint.AddChild(kitchenObjectInstance);
	}
}
