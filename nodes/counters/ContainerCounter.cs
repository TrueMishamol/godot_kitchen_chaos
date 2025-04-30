using Godot;
using System;

public partial class ContainerCounter : BaseCounter {


	public event Action OnPlayerGrabObject;

	[Export] private KitchenObjectResource _KitchenObjectResource;


	public override void Interact(Player player) {
		if (player.KitchenObject == null) {
			// Spawn new Kitchen Object
			PackedScene packedScene = GD.Load<PackedScene>(_KitchenObjectResource._SceneFilePath);
			KitchenObject kitchenObjectInstance = packedScene.Instantiate<KitchenObject>();

			// Give it to a player
			kitchenObjectInstance.KitchenObjectParent = player;

			OnPlayerGrabObject?.Invoke();
		}
	}
}
