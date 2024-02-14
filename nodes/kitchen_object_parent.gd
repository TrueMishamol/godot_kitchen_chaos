class_name KitchenObjectParent
extends Node3D


var _kitchen_object: KitchenObject


func set_kitchen_object(new_kitchen_object: KitchenObject):
	_kitchen_object = new_kitchen_object
	

func get_kitchen_object() -> KitchenObject:
	return _kitchen_object
	
	
func clear_kitchen_object():
	_kitchen_object = null
	
	
func has_kitchen_object() -> bool:
	return _kitchen_object != null
