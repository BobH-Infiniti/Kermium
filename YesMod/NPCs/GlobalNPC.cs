using System;
using System.Collections.Generic;
using YesMod.Buffs;

using YesMod.Items;
using YesMod.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using static Terraria.Player;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using YesMod;



namespace YesMod.NPCs
{
	public class NPCsGLOBAL : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		
		public bool KermiumAffliction;
		
		public override void ResetEffects(NPC npc)
		{
			
			KermiumAffliction = false;
		}


		


		public override void SetDefaults(NPC npc)
		{
			
			


		}




		public override void UpdateLifeRegen(NPC npc, ref int damage)// unrlated to th invasion
		{

			
			
			if (KermiumAffliction)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 25;
				if (damage < 2)
				{
					
					
					damage = 1;
				}
				
				
				
			}
			if (npc.drippingSlime)
			{
				npc.defense -= 1;
				npc.damage -= 1;
				
			}
			



		}  




		
}	}