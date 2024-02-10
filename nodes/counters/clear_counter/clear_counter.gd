class_name ClearCounter 
extends StaticBody3D


@export var _kitchen_object_res: KitchenObjectRes
@export var _counter_top_point: Node3D


func interact():
	print("Interact!")
	var kitchen_object_res = load(_kitchen_object_res.node).instantiate()
	_counter_top_point.add_child(kitchen_object_res)
	
	print((kitchen_object_res as KitchenObject).get_resource().object_name)
