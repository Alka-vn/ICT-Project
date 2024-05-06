extends Node2D
#1.load the scene
var fruitScene:PackedScene = load("res://scenes/fruit.tscn")

func _on_fruit_timer_timeout():
	#2.create the scene
	var fruit = fruitScene.instantiate()
	print("fruit instantiated")
	$Fruits.add_child(fruit)


func _on_game_timer_timeout():
	print("exit game");
	#get_tree().quit()
