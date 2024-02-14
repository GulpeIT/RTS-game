using Godot;

public partial class main_camera_2d : Camera2D
{
	[Export] float _cameraSpeed = 1.2f;
	[Export] float _cameraEdge = 4f;

	[Export] bool _canMoveByEdge = true;

	[Export] float _zoomSpeed = 0.6f;
	[Export] float _zoomMax = 1f;
	[Export] float _zoomMin = 1.6f;

	Vector2 _start_position;
	Vector2 _mouse_position;
	bool _dragging;

	public override void _Ready(){
		base._Ready();
		
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsAction("uc_rightMouseButtonClick"))
		{
			if (@event is InputEventMouseButton eventMouse)
			{
				if (eventMouse.IsPressed())
				{
					_start_position = Position;
					_mouse_position = eventMouse.Position;
					_dragging = true;
				}
				else _dragging = false;
			}
		}
		else if (@event is InputEventMouseMotion eventMouseM && _dragging)
		{
			Vector2 newPos = ((_mouse_position - eventMouseM.Position) / Zoom) + _start_position;
			Position = newPos;
		}
	}

	public override void _Process(double delta){
		CameraZoom((float)delta);
		if (_canMoveByEdge) CameraEdgeMove();
	}

	/// <summary>
	/// Метод управлением камеры
	/// </summary>
	void CameraEdgeMove(){
		// Позиция курсора на Viewport
		Vector2 localMousePosition = GetViewport().GetMousePosition();

		if (_canMoveByEdge){
			// Передвижение влево
			if (localMousePosition.X <= _cameraEdge || Input.IsActionPressed("uc_left")){
				Position -= new Vector2(_cameraSpeed, 0);
			}
			// Передвижение в право
			else if (localMousePosition.X >= GetViewportRect().Size.X - _cameraEdge || Input.IsActionPressed("uc_right")){
				Position += new Vector2(_cameraSpeed, 0);
			}
			// Передвижение в верх
			if (localMousePosition.Y <= _cameraEdge || Input.IsActionPressed("uc_up")){
				Position -= new Vector2(0, _cameraSpeed);
			}
			// Передвижение вниз
			else if (localMousePosition.Y >= GetViewportRect().Size.Y - _cameraEdge || Input.IsActionPressed("uc_down")){
				Position += new Vector2(0, _cameraSpeed);
			}
		}
	}
	
	/// <summary>
	/// Метод приближения камеры
	/// </summary>
	/// <param name="delta"></param>
	void CameraZoom(float delta){
		if (Input.IsActionPressed("uc_zoomIn")){
			Zoom += new Vector2(_zoomSpeed, _zoomSpeed) * delta;
		}
		else if (Input.IsActionPressed("uc_zoomOut")){
			Zoom -= new Vector2(_zoomSpeed, _zoomSpeed) * delta;
		}
		// Ограничение приближения и увелечения камеры
		Zoom = Zoom.Clamp(new Vector2(_zoomMax, _zoomMax), new Vector2(_zoomMin, _zoomMin));
	}

	/// <summary>
	/// Метод переключения параметра перемещения по краю экрана
	/// </summary>
	/// <param name="toggled_on"></param>
	private void _on_move_by_edge_check_button_toggled(bool toggled_on){
		_canMoveByEdge = toggled_on;
	}
}





