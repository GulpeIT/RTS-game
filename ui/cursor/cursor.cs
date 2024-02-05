using Godot;
using System;
using System.ComponentModel.Design;
using System.Reflection;

public partial class player_cursor : Node2D
{
	[Export] Sprite2D sprite;
	ColorRect selectedArea;
	
	Vector2 firstCursorPosition;

	public override void _Ready(){
		//Скрытие системного курсора
		DisplayServer.MouseSetMode(DisplayServer.MouseMode.Hidden);
		selectedArea = (ColorRect)GetNode("SelectedArea");
	}


	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		
		//Анимация для курсора
		if (Input.IsActionPressed("uc_leftButtonClick")){
			sprite.Frame = 1;
		}
		else{
			sprite.Frame = 0;
		}

	}

	public override void _Process(double delta){
		//Присвоение позиции для кастомного курсора
		Position = GetGlobalMousePosition();
	}
}
