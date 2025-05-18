using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class HopeRevival : ModBuff
	{

		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Hope Revival");
			// Description.SetDefault("You can't be revived by Hope.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(Player player, ref int buffIndex) {

		

		}
	}
}

