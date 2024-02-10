#@tool
class_name KitchenObject
extends Node3D


@export var _kitchen_object_res: KitchenObjectRes

var _clear_counter: ClearCounter


func get_resource() -> KitchenObjectRes:
	return _kitchen_object_res


func set_clear_counter(clear_counter: ClearCounter):
	if _clear_counter != null:
		_clear_counter.clear_kitchen_object()
	
	_clear_counter = clear_counter
	
	if clear_counter.has_kitchen_object():
		printerr("Counter already has a Kitchen Object!")
	
	clear_counter.set_kitchen_object(self)
	
	reparent(clear_counter.get_counter_top_point())
	position = Vector3.ZERO


func get_clear_counter() -> ClearCounter:
	return _clear_counter
