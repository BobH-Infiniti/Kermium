using System;
using System.Collections.Generic;
using YesMod.Buffs;
using Terraria.GameContent.ItemDropRules;
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

		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {



			


			if (npc.type == NPCID.CursedSkull)
			{
				
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.NecroticWand>(), 50));
				   
			}
			if (npc.type == 113) //Wall of Flesh
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.LostEmblem>(), 10));

			}
			if (npc.type == NPCID.DungeonSpirit) 
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.GhastlyHatchet>(), 100));

			}
			if (npc.type == NPCID.GreekSkeleton)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.MarvelousMarble>(), 100));

			}
			if (npc.type == NPCID.EaterofSouls)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.InfectedFlesh>(), 100));

			}
			if (npc.type == NPCID.IceSlime)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.FrigidCrystal>(), 5));

			}
			if (npc.type == NPCID.IceBat)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.FrigidCrystal>(), 5));

			}
			if (npc.type == NPCID.SkeletronHead)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.KermiumBar>(), 1, 15, 20));

			}
		
			if (npc.type == 182) //Floaty Gross
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.BloodcoreCleaver>(), 50));

			}





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