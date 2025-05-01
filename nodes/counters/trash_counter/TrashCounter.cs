public partial class TrashCounter : BaseCounter {

	public override void Interact(Player player) {
		if (player.KitchenObject != null) {
			player.KitchenObject.DestroySelf();
		}
	}
}
