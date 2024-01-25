using Godot;
using System;

public partial class damagePackage : Node
{
	// Наносимый урон
	private float damage;
	// Пробивная способность
	private float penetration;
	
	public damagePackage(float damage, float penetration){
		this.damage = damage;
		this.penetration = penetration;
	}
		
	/// <summary>
	/// Получение значения наносимого урона.
	/// </summary>
	/// <returns></returns>
	public float GetDamage(){
		return damage;
	}

	/// <summary>
	/// Получение значения пробивной способности.
	/// </summary>
	/// <returns></returns>
	public float GetPenetration(){
		return penetration;
	}
}
