using Godot;

public partial class CuttingCounter : BaseCounter {


	[Export] public CuttingRecipesListResource _CuttingRecipesListResource;


	public override void Interact(Player player) {
		if (KitchenObject == null) {
			//# Counter EMPTY
			if (player.KitchenObject != null) {
				//# Player HAS object
				if (HasRecipeWithInput(player.KitchenObject._KitchenObjectResource)) {
					// Object has recipe
					player.KitchenObject.KitchenObjectParent = this;
				}
			}
		} else {
			//# Counter HAS object
			if (player.KitchenObject == null) {
				//# Player EMPTY-handed
				KitchenObject.KitchenObjectParent = player;
			}
		}
	}

	public override void InteractAlternate(Player player) {
		if (KitchenObject != null) {
			KitchenObjectResource outputKitchenObjectResource = GetOutputForInput(KitchenObject._KitchenObjectResource);
			if (outputKitchenObjectResource == null)
				return;

			KitchenObject.DestroySelf();
			KitchenObject.SpawnKitchenObject(outputKitchenObjectResource, this);
		}
	}

	private bool HasRecipeWithInput(KitchenObjectResource input) {
		foreach (CuttingRecipeResource recipe in _CuttingRecipesListResource._CuttingRecipeResources) {
			if (recipe._Input == input) {
				return true;
			}
		}
		return false;
	}

	private KitchenObjectResource GetOutputForInput(KitchenObjectResource input) {
		foreach (CuttingRecipeResource recipe in _CuttingRecipesListResource._CuttingRecipeResources) {
			if (recipe._Input == input) {
				return recipe._Output;
			}
		}
		return null;
	}
}
