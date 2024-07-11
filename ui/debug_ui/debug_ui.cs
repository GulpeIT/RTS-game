using Godot;

public partial class debug_ui : Control{
	
	[Export] bool _show = false;

	[Export] Label FPSCount;

	public override void _Ready(){
		base._Ready();
		FPSCount = GetNode<Label>("FPSCountLabel");

		Visible = _show;
	}

	public override void _Process(double delta){
		base._Process(delta);

		FPSCount.Text = $"FPS :{Engine.GetFramesPerSecond()}";
	}

	public override void _Input(InputEvent @event){
		base._Input(@event);

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
}





