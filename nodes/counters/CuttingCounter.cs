using Godot;

public partial class CuttingCounter : BaseCounter {


	[Export] public KitchenObjectResource _KitchenObjectResource { get; private set; }


	public override void Interact(Player player) {
		if (KitchenObject == null) {
			//# Empty
			if (player.KitchenObject != null) {
				//# NOT Emptyhanded
				player.KitchenObject.KitchenObjectParent = this;
			}
		} else {
			//# NOT Empty
			if (player.KitchenObject == null) {
				//# Emptyhanded
				KitchenObject.KitchenObjectParent = player;
			}
		}
	}

	public override void InteractAlternate(Player player) {
		if (KitchenObject != null) {
			KitchenObject.DestroySelf();
			KitchenObject.SpawnKitchenObject(_KitchenObjectResource, this);
		}
	}
}
