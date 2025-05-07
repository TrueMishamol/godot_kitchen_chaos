public partial class DeliveryCounter : BaseCounter {

	public override void Interact(Player player) {
		if (player.KitchenObject != null) {
			if (player.KitchenObject.TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
				// Only accepts Plates

				DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
				
				player.KitchenObject.DestroySelf();
			}
		}
	}
}
