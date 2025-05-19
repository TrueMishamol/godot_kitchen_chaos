using System;

public partial class TrashCounter : BaseCounter {


	public event Action OnTrash;



	public override void Interact(Player player) {
		if (player.KitchenObject != null) {
			player.KitchenObject.DestroySelf();
			OnTrash?.Invoke();
		}
	}
}
