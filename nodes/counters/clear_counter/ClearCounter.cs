public partial class ClearCounter : BaseCounter {

	public override void Interact(Player player) {
		if (KitchenObject == null) {
			// Counter EMPTY
			if (player.KitchenObject != null) {
				// Player HAS object
				//# Player drops the object
				player.KitchenObject.KitchenObjectParent = this;
				InvokeOnObjectDrop();
			}
		} else {
			// Counter HAS object
			if (player.KitchenObject == null) {
				// Player EMPTY-handed
				//# Player grabs the object
				KitchenObject.KitchenObjectParent = player;
			} else {
				// Player HAS object
				if (player.KitchenObject.TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
					// Player is holding a Plate
					//# Player has Plate
					if (plateKitchenObject.TryAddIngredient(KitchenObject._KitchenObjectResource)) {
						KitchenObject.DestroySelf();
					}
				} else {
					// Player is not holding a Plate but something else
					if (KitchenObject.TryGetPlate(out plateKitchenObject)) {
						// Counter is holding a Plate
						//# Counter has Plate
						if (plateKitchenObject.TryAddIngredient(player.KitchenObject._KitchenObjectResource)) {
							player.KitchenObject.DestroySelf();
						}
					}
				}
			}
		}
	}
}
