public partial class ClearCounter : BaseCounter {

	public override void Interact(Player player) {
		if (KitchenObject == null) {
			// Counter EMPTY
			if (player.KitchenObject != null) {
				// Player HAS object
				//# Player drops the object
				player.KitchenObject.KitchenObjectParent = this;
			}
		} else {
			// Counter HAS object
			if (player.KitchenObject == null) {
				// Player EMPTY-handed
				//# Player grabs the object
				KitchenObject.KitchenObjectParent = player;
			}
		}
	}
}
