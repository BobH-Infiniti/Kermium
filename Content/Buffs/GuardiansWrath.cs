using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class GuardiansWrath : ModBuff
	{

		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Guardian's Wrath");
			// Description.SetDefault("[c/00FFFF:True pain.]");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCsGLOBAL>().GuardiansWrath = true;
		}
	}
}

