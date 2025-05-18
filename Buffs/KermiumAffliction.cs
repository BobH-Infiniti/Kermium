using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class KermiumAffliction : ModBuff
	{

		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Kermium Affliction");
			// Description.SetDefault("An ancient power is dissolving your soul.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCsGLOBAL>().KermiumAffliction = true;
		}
	}
}
