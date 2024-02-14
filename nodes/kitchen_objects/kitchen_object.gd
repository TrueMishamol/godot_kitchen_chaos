#@tool
class_name KitchenObject
extends Node3D


@export var _kitchen_object_res: KitchenObjectRes

var _kitchen_object_parent: KitchenObjectParent


func get_resource() -> KitchenObjectRes:
	return _kitchen_object_res


func set_kitchen_object_parent(new_kitchen_object_parent: KitchenObjectParent):
	if _kitchen_object_parent != null:
		_kitchen_object_parent.clear_kitchen_object()
	
	_kitchen_object_parent = new_kitchen_object_parent
	
	if new_kitchen_object_parent.has_kitchen_object():
		printerr("Counter already has a Kitchen Object!")
	
	new_kitchen_object_parent.set_kitchen_object(self)
	
	reparent(new_kitchen_object_parent)
	position = Vector3.ZERO


func get_kitchen_object_parent() -> KitchenObjectParent:
	return _kitchen_object_parent
