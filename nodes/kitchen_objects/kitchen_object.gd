#@tool
class_name KitchenObject
extends Node3D


@export var _kitchen_object_res: KitchenObjectRes

var _clear_counter: ClearCounter


func get_resource() -> KitchenObjectRes:
	return _kitchen_object_res

func set_clear_counter(clear_counter: ClearCounter):
	_clear_counter = clear_counter

func get_clear_counter() -> ClearCounter:
	return _clear_counter
