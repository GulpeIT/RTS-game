using Godot;
using System;

public partial class main_camera_2d : Camera2D
{
	[Export] private float cameraSpeed = 1.2f;
	[Export] private float cameraEdge = 4f;
	
	[Export] private bool cameraCanMove = true;
	

	public override void _Process(double delta){
		if (cameraCanMove){
			CameraMove();
		}

	}


	/// <summary>
	/// Метод управлением камеры
	/// </summary>
	void CameraMove(){
		// Позиция курсора на Viewport
		Vector2 localMousePosition = GetViewport().GetMousePosition();

		if (cameraCanMove){
			// Передвижение влево
			if (localMousePosition.X <= cameraEdge || Input.IsActionPressed("uc_left")){
				Position -= new Vector2(cameraSpeed, 0);
			}
			// Передвижение в право
			if (localMousePosition.X >= GetViewportRect().Size.X - cameraEdge || Input.IsActionPressed("uc_right")){
				Position += new Vector2(cameraSpeed, 0);
			}
			// Передвижение в верх
			if (localMousePosition.Y <= cameraEdge || Input.IsActionPressed("uc_up")){
				Position -= new Vector2(0, cameraSpeed);
			}
			// Передвижение вниз
			if (localMousePosition.Y >= GetViewportRect().Size.Y - cameraEdge || Input.IsActionPressed("uc_down")){
				Position += new Vector2(0, cameraSpeed);
			}
		}
	}

	//TODO:
	// Реализовать метод приближение, через колёсико мышки
	void CameraZoom(){
	}
}
