extends Node


@export var _clear_counter: ClearCounter
@export var _visuals: Array[Node3D]


func _ready():
	var player = Singleton.player as Player
	player.on_selected_counter_changed.connect(_on_selected_counter_changed)


func _on_selected_counter_changed(selected_counter: ClearCounter):
	if selected_counter == _clear_counter:
		_show()
	else:
		_hide()


func _show():
	for visual in _visuals:
		visual.visible = true


func _hide():
	for visual in _visuals:
		visual.visible = false
