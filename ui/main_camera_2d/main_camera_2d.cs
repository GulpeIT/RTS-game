using Godot;

public partial class main_camera_2d : Camera2D
{
	[Export] public float _cameraSpeed = 1.2f;
	[Export] public float _cameraEdge = 4f;

	[Export] public bool _canMoveByEdge = false;
	private bool _dragging;

	[Export] public float _zoomSpeed = 0.6f;
	[Export] public float _zoomMax = 1f;
	[Export] public float _zoomMin = 1.6f;

	private Vector2 _startPosition;
	private Vector2 _mousePosition;

	private float _delta;


    public override void _UnhandledInput(InputEvent @event){
		#region Передвижение камеры правой кнопкой мыши
		if (@event.IsAction("uc_rightMouseButtonClick"))
		{
			if (@event is InputEventMouseButton eventMouse)
			{
				if (eventMouse.IsPressed())
				{
					_startPosition = Position;
					_mousePosition = eventMouse.Position;
					_dragging = true;
				}
				else _dragging = false;
			}
		}
		else if (@event is InputEventMouseMotion eventMouseM && _dragging)
		{
			Vector2 newPos = ((_mousePosition - eventMouseM.Position) / Zoom) + _startPosition;
			Position = newPos;
		}
		#endregion

		#region Приближение камеры на колёсико мышки
		if (@event is InputEventMouseButton eventMiddleMouse){
			if (eventMiddleMouse.ButtonIndex == MouseButton.WheelUp){
				CameraZoom(_zoomSpeed * 10f);
			}
			else if (eventMiddleMouse.ButtonIndex == MouseButton.WheelDown){
				CameraZoom(-_zoomSpeed * 10f);
			}
		}
		#endregion 
	}

	public override void _Process(double delta){
		_delta = (float)delta;
		if (_canMoveByEdge) CameraEdgeMove();

		CameraZoom();
		// Ограничение приближение камеры
		Zoom = Zoom.Clamp(new Vector2(_zoomMax, _zoomMax), new Vector2(_zoomMin, _zoomMin));
	}

	/// <summary>
	/// Метод управлением камеры
	/// </summary>
	private void CameraEdgeMove(){
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
	private void CameraZoom(){
		if (Input.IsActionPressed("uc_zoomIn")){
			Zoom += new Vector2(_zoomSpeed, _zoomSpeed) * _delta;
		}
		else if (Input.IsActionPressed("uc_zoomOut")){
			Zoom -= new Vector2(_zoomSpeed, _zoomSpeed) * _delta;
		}
	}
	private void CameraZoom(float zoomSpeed){
		Zoom += new Vector2(zoomSpeed, zoomSpeed) * _delta;
	}

	/// <summary>
	/// Метод переключения параметра перемещения по краю экрана
	/// </summary>
	/// <param name="toggled_on"></param>
	private void _on_move_by_edge_check_button_toggled(bool toggled_on){
		_canMoveByEdge = toggled_on;
	}
}





