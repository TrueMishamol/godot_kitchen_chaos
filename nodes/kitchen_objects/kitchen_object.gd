#@tool
extends Node3D


@export var _kitchen_object_res: KitchenObjectRes

#@export var scene: String


#@export var node_path: String = "/*.tscn"
#@export var sprite_path = "/*.png"
#@export var object_name: String


func _process(_delta):
	pass
	#print (get_tree().current_scene.scene_file_path)
	#scene = get_tree().edited_scene_root.get_script().get_path()
	##scene = get_tree().
