extends Node3D

func _process(delta):
	if get_child_count() == 0:
		print("You won!")
