using Godot;

public partial class main_ui : Control {
	Button closeButton;

	public override void _Ready(){
		closeButton = GetNode<Button>("CloseGame");
	}

	public override void _Process(double delta){
	}

	private void _on_close_game_button_pressed(){
		GetTree().Quit();
	}
}
