using Godot;

public partial class cursor : Node2D
{
	[Export] Sprite2D sprite;	
	Vector2 firstCursorPosition;

	public override void _Ready(){
		//Скрытие системного курсора
		DisplayServer.MouseSetMode(DisplayServer.MouseMode.Hidden);
	}

	public override void _Process(double delta){
		//Присвоение позиции для кастомного курсора
		Position = GetGlobalMousePosition();

		//Анимация для курсора
		if (Input.IsActionPressed("uc_leftButtonClick")){
			sprite.Frame = 1;
		}
		else{
			sprite.Frame = 0;
		}
	}
}
