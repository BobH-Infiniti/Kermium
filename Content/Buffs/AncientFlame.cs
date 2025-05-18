using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class AncientFlame : ModBuff
	{

		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ancient Flames");
			// Description.SetDefault("Your very soul is melting");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCsGLOBAL>().RealRodOfDiscord = true;
		}
	}
}

