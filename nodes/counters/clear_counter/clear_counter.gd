class_name ClearCounter 
extends StaticBody3D


@export var _kitchen_object_res: KitchenObjectRes
@export var _counter_top_point: Node3D

var _kitchen_object: KitchenObject;


func interact():
	if _kitchen_object == null:
		var kitchen_object_instance = load(_kitchen_object_res.node).instantiate()
		_counter_top_point.add_child(kitchen_object_instance)
		
		_kitchen_object = kitchen_object_instance
		_kitchen_object.set_clear_counter(self)
	else:
		print(_kitchen_object.get_clear_counter())
