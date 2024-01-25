using Godot;
using System;

public partial class healthComponent : Node2D
{
	[Export] public float health;
	[Export] public float defense;
	
	public void TakeDamage(damagePackage damage){
		health -= Mathf.Max(damage.GetDamage() - Mathf.Max(defense - damage.GetPenetration(), 0), 0);
	}

	public float GetHealth(){
		return health;
	}
}
