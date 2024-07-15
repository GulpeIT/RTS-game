using Godot;

public partial class main_ui : Control {

	public override void _Ready(){}

    public override void _Input(InputEvent @event){
		if (@event.IsActionPressed("ui_close")){
			GetTree().Quit();
		}
    }

    public override void _Process(double delta){
	}

	public void _on_close_game_button_pressed(){
		GetTree().Quit();
	}
}
