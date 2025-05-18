using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class GraniteCurse : ModBuff
	{

		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Granite Curse");
			// Description.SetDefault("Your blood is petrifying");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCsGLOBAL>().Granoot = true;
		}
	}
}

