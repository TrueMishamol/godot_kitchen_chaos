class_name KitchenObjectParent
extends Node3D


var kitchen_object: KitchenObject


func set_kitchen_object(new_kitchen_object: KitchenObject):
	kitchen_object = new_kitchen_object
	

func get_kitchen_object() -> KitchenObject:
	return kitchen_object
	
	
func clear_kitchen_object():
	kitchen_object = null
	
	
func has_kitchen_object() -> bool:
	return kitchen_object != null
