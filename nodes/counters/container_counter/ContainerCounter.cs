using Godot;
using System;

public partial class ContainerCounter : BaseCounter {


	public event Action OnPlayerGrabObject;

	[Export] public KitchenObjectResource _KitchenObjectResource { get; private set; }



	public override void Interact(Player player) {
		if (player.KitchenObject == null) {
			KitchenObject.SpawnKitchenObject(_KitchenObjectResource, player);

			OnPlayerGrabObject?.Invoke();
		}
	}
}
