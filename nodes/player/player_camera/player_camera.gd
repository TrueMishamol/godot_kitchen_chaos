extends Camera3D


@export var target: Node3D

@onready var camera_follow: CameraFollow = $CameraFollow


func _ready() -> void:
	camera_follow.target = target
