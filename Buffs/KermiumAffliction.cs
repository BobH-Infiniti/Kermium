using Microsoft.Xna.Framework;
using YesMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace YesMod.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class KermiumAffliction : ModBuff
	{

		

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Kermium Affliction");
			Description.SetDefault("An ancient power is dissolving your soul.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCsGLOBAL>().KermiumAffliction = true;
		}
	}
}
