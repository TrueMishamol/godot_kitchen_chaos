using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class PlateKitchenObject : KitchenObject {


	[Export] private KitchenObjectsListResource _ValidKitchenObjects;

	private List<KitchenObjectResource> kitchenObjectResourcesList = new List<KitchenObjectResource>();


	// public override void _EnterTree() {
	// 	kitchenObjectResourcesList = new List<KitchenObjectResource>();
	// }

	public bool TryAddIngredient(KitchenObjectResource kitchenObjectResource) {
		if (!_ValidKitchenObjects._KitchenObjectResources.Contains(kitchenObjectResource)) {
			// Not a valid ingredient
			return false;
		}

		if (kitchenObjectResourcesList.Contains(kitchenObjectResource)) {
			// Already has this type
			return false;
		}

		kitchenObjectResourcesList.Add(kitchenObjectResource);
		return true;
	}

}
