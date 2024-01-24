using Godot;
using System;

public partial class player_cursor : Node2D
{
	//Спрайт курсора || Cursor sprite
	[Export] private Sprite2D sprite;

	

	public override void _Ready(){
		// Скрытие системного курсора || Hide system cursor
		DisplayServer.MouseSetMode(DisplayServer.MouseMode.Hidden);
	}

	public override void _Process(double delta){
		//Присвоение позиции для собственного курсора || Assigning a position for custom cursor
		Position = GetGlobalMousePosition();

		//Анимация для курсора || Animation for cursor
		if (Input.IsActionPressed("uc_leftMouseClick")){
			sprite.Frame = 1;
		}
		else{
			sprite.Frame = 0;
		}
	}

}
