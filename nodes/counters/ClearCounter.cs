using Godot;

public partial class ClearCounter : BaseCounter {


	[Export] private KitchenObjectResource _KitchenObjectResource;


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
}
