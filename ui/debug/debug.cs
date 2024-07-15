using Godot;

public partial class debug : Control{
	
	[Export] private bool _show = false;
	[Export] private Label _FPSCount;
	private Camera2D _camera;


	public override void _Ready(){
		base._Ready();
		_FPSCount = GetNode<Label>("FPSCountLabel");
		_camera = FindParent("MainWorld").GetNode<Camera2D>("MainCamera2D");
		Visible = _show;

		
	}

	public override void _Process(double delta){
		base._Process(delta);
		
		_FPSCount.Text = $"FPS :{Engine.GetFramesPerSecond()}";
	}

	public override void _Input(InputEvent @event){
		if (Input.IsActionJustPressed("ui_debug") && !_show){
			_show = true;
			Visible = _show;
		}
		else if (Input.IsActionJustPressed("ui_debug") && _show){
			_show = false;
			Visible = _show;
		}

		
	}

	/// <summary>
	/// Метод изменения разрешения окна.
	/// </summary>
	/// <param name="toggled_on"></param>
	private void _on_full_screen_check_button_toggled(bool toggled_on){
		if (toggled_on){
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.ExclusiveFullscreen);
		}
		else{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
		}
	}

	/// <summary>
	/// Метод включения движения по краю экрана (для удобства разработки)
	/// </summary>
	/// <param name="toggled_on"></param>
	private void _on_move_by_edge_check_button_toggled(bool toggled_on){
		if (_camera is main_camera_2d camera2D){
			camera2D._canMoveByEdge = toggled_on;
		}
	}
}





