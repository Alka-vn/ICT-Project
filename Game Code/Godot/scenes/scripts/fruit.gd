extends Node2D

var speed : int
var rotation_speed: int
var direction_x : float

var width 
var height 
# Called when the node enters the scene tree for the first time.
func _ready():
	var rng := RandomNumberGenerator.new()
	#start position
	width = get_viewport().get_visible_rect().size[0]
	height = get_viewport().get_visible_rect().size[1]
	var buffer = 0.01*width;
	var random_x = rng.randi_range(buffer,width-buffer)
	var random_y = rng.randi_range(-150,-50)
	position = Vector2(random_x,random_y)
	
	speed = rng.randi_range(200,500)
	direction_x = rng.randf_range(-0.6,0.6)
	rotation_speed = rng.randi_range(80,100)
	print(height,width);


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	position += Vector2(direction_x,1.0)*speed*delta;
	rotation_degrees += rotation_speed * delta
	
	
