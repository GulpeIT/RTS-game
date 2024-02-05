using Godot;

public partial class test_worker_car : CharacterBody2D
{	
	[Export] float acceleration = 4.5f;
	[Export] float speedMax = 100.0f;
	[Export] float friction = 1.0f;
	
	Vector2 velocity = Vector2.Zero;
	
	[Export] Sprite2D wheelbase;
	[Export] Sprite2D tower;
	
	Sprite2D selectFrame;

	
	public override void _Ready(){
		selectFrame = GetNode<Sprite2D>("SelectFrame");
	}

	
	public override void _Process(double delta){ 
		MoveAndCollide(velocity);
	}
}
