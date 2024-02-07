using Godot;


// TODO: 
// 1. Создать отдельный класс "Unit"
// 2. Образовать наследование классов "test_worker_car" > "Unit"
public partial class test_worker_car : CharacterBody2D
{	
	[Export] float acceleration = 4.5f;
	[Export] float speedMax = 100.0f;
	[Export] float friction = 1.0f;
	
	Vector2 velocity = Vector2.Zero;
	
	[Export] Sprite2D wheelbase;
	[Export] Sprite2D tower;
	
	Sprite2D selectFrame;
	bool selected = false;
	
	// Игровые можно будет брать под полный контроль и
	// управлять с помощью "wasd" или другой конфигурации
	bool underControl = false;

	public override void _Ready(){
		selectFrame = GetNode<Sprite2D>("SelectFrame");
	}
	public override void _Process(double delta){ 
		MoveAndCollide(velocity);
	}

	// TODO: 
	// Сделать методы "Выделения" и "Сброса Выделения" для рабочей машины
	public void Select(){
		selected = true;
		selectFrame.Visible = true;
	}
	public void UnSelect(){
		selected = false;
		selectFrame.Visible = false;
	}
}
