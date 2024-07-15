using System.Collections.Generic;
using System.Net;
using Godot;

public partial class main_menu : Control {

	[Export] public PackedScene startGameScene;

	public override void _Ready(){
	}


	public override void _Process(double delta){
	}

	private void _on_button_start_game_pressed(){
		GetTree().ChangeSceneToPacked(startGameScene);
	}

	private void _on_button_settings_pressed(){

	}
	private void _on_button_exit_pressed(){
		GetTree().Quit();
	}
}
