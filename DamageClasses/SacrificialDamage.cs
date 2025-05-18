using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace KermiumMod.DamageClasses
{
	public class SacrificialClass : DamageClass
	{
		public override void SetStaticDefaults()
		{
			
			// DisplayName.SetDefault("sacrificial damage");
		}
		
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
		{

			if (damageClass == DamageClass.Generic)
				return StatInheritanceData.None;

			return new StatInheritanceData(
				damageInheritance: 1f,
				critChanceInheritance: 1f,
				attackSpeedInheritance: 1f,
				armorPenInheritance: 1f,
				knockbackInheritance: 1f
			);
		}

		public override bool GetEffectInheritance(DamageClass damageClass)
		{

			


			return false;
		}
	}
}