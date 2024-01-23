# Put in Autoload

extends Node


func _input(event):
	if event.is_action_pressed("fullscreen"):
		_toggle_fullscreen()
	
	if event.is_action_pressed("quit"):
		get_tree().quit()


func _toggle_fullscreen():
	if DisplayServer.window_get_mode() == DisplayServer.WINDOW_MODE_FULLSCREEN:
		DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_WINDOWED)
	else:
		DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_FULLSCREEN)
