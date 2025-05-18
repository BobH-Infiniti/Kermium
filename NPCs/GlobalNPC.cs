using System;
using Terraria.Graphics.CameraModifiers;
using System.Collections.Generic;
using KermiumMod.Buffs;
using Terraria.GameContent.ItemDropRules;
using KermiumMod.Items;
using KermiumMod.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using static Terraria.Player;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using KermiumMod;



namespace KermiumMod.NPCs
{
	public class NPCsGLOBAL : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		
		public bool KermiumAffliction;
		public bool GuardiansWrath;
		public bool Granoot;
		public bool RealRodOfDiscord;
		
		public override void ResetEffects(NPC npc)
		{
			
			KermiumAffliction = false;
			GuardiansWrath = false;
			Granoot = false;
			RealRodOfDiscord = false;
		}


		


		public override void SetDefaults(NPC npc)
		{
			
			


		}

		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
			Player player = Main.player[0];

			//The hero sword item I literally never use
			if (npc.type == NPCID.Mothron)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.DecayedHeroRune>(), 2));

			}

			//Necrotic Wand
			if (npc.type == NPCID.CursedSkull)
			{
				
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.NecroticWand>(), 50));
				   
			}

			//Lost Emblem
			if (npc.type == 113) //Wall of Flesh
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.LostEmblem>(), 10));

			}
			
			//Marvelous Marble
			if (npc.type == NPCID.GreekSkeleton)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.MarvelousMarble>(), 100));

			}

			//Infected Flesh
			if (npc.type == NPCID.EaterofSouls)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.InfectedFlesh>(), 100));

			}
			
			//Frigid Crystals
			if (npc.type == NPCID.IceSlime)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.FrigidCrystal>(), 4));


			}
			if (npc.type == NPCID.SpikedIceSlime)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.FrigidCrystal>(), 3));

			}
			if (npc.type == NPCID.IceBat)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.FrigidCrystal>(), 3));

			}

			//Kermium Bars since I'm too lazy to implement real generation lol
			if (npc.type == NPCID.SkeletronHead)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.KermiumBar>(), 1, 15, 20));

			}

			//Bloodcore Cleaver
			if (npc.type == 182) //Floaty Gross
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.BloodcoreCleaver>(), 50));

			}

			//Granite Shell
			if (npc.type == NPCID.GraniteFlyer)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.Granoot>(), 100));

			}
			if (npc.type == NPCID.GraniteGolem)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.Granoot>(), 100));

			}

			//Tribal Pendant
			if (npc.type == NPCID.Hornet)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.TribalPendant>(), 100));

			}
			if (npc.type == NPCID.JungleBat)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.TribalPendant>(), 100));

			}
			if (npc.type == NPCID.Snatcher)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.TribalPendant>(), 100));

			}
			if (npc.type == NPCID.SpikedJungleSlime)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.TribalPendant>(), 100));

			}
			if (npc.type == NPCID.ManEater)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.TribalPendant>(), 100));

			}

			//Permafrost Pendant
			if (npc.type == NPCID.UndeadViking)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.PermafrostPendant>(), 100));

			}
			if (npc.type == NPCID.IceBat)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.PermafrostPendant>(), 100));

			}
			if (npc.type == NPCID.SpikedIceSlime)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.PermafrostPendant>(), 100));

			}
			if (npc.type == NPCID.SnowFlinx)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.PermafrostPendant>(), 100));

			}
			if (npc.type == NPCID.IceGolem)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.PermafrostPendant>(), 10));

			}
			
			//Divine Acorn
			if (npc.type == NPCID.Squirrel)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.DivineAcorn>(), 100));

			}

			//Enchanted Mushroom
			if (npc.type == NPCID.SporeSkeleton)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.Flushroom>(), 100));

			}
			if (npc.type == NPCID.SporeBat)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.Flushroom>(), 100));

			}

			//Shard of the Stars
			if (npc.type == NPCID.MeteorHead)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.MeteoriteCluster>(), 50));

			}

			//Holy Virtue
			if (npc.type == NPCID.Pixie)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.HolyVirtue>(), 100));

			}
			if (npc.type == NPCID.Unicorn)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.HolyVirtue>(), 100));

			}
			
			

			//Engorged Voodoo Doll
			if (npc.type == 66) //Voodoo Demon
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.EngorgedDoll>(), 50));
			}

			//Aquatic Jawbreaker
			if (npc.type == 65) //Shark
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.AquaticJawbreaker>(), 50));
			}

			//Broken Nazar
			if (npc.type == 34) //Cursed Skull
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BrokenNazar>(), 100));
			}
			if (npc.type == 289) //Giant Cursed Skull
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BrokenNazar>(), 50));
			}

			//Dried Arcanum
			if (npc.type == 69) //Antlion
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.DriedArcanum>(), 100));
			}
			if (npc.type == 508) //Antlion Charger
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.DriedArcanum>(), 100));
			}
			if (npc.type == 509) //Antlion Swarmer
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.DriedArcanum>(), 100));
			}
			if (npc.type == 580) //Antlion Charger
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.DriedArcanum>(), 100));
			}
			if (npc.type == 581) //Antlion Swarmer
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.DriedArcanum>(), 100));
			}
			if (npc.type == 582) //Antlion Larva
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.DriedArcanum>(), 200));
			}

			
			if (npc.type == 151) //Lava Bat
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.SearingShard>(), 1, 1, 4));
			}
			if (npc.type == 156) //Red Devil
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.SearingShard>(), 1, 1, 6));
			}
			
			
			
		}

	


		public override void UpdateLifeRegen(NPC npc, ref int damage)
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
			
			if (GuardiansWrath)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 25;
				if (damage < 2)
				{


					damage = 7;
				}



			}
			if (Granoot)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 30;
				if (damage < 2)
				{


					damage = 1;
				}



			}
			if (RealRodOfDiscord)
			{
				npc.defense -= 5;
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 80;
				if (damage < 2)
				{


					damage = 1;
				}



			}
		}





			public override void DrawEffects(NPC npc, ref Color drawColor)
            {
			     if (Granoot)
                 {
				   int num249 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 240, npc.velocity.X, npc.velocity.Y, 50, default(Color), 1.2f);
				   Main.dust[num249].noGravity = true;
				   Dust dust2 = Main.dust[num249];
				   dust2.velocity *= 0.3f;
			     }
			     if (GuardiansWrath)
			     {
				   int num249 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 44, npc.velocity.X, npc.velocity.Y, 50, default(Color), 1.2f);
				   Main.dust[num249].noGravity = true;
				   Dust dust2 = Main.dust[num249];
				   dust2.velocity *= 0.3f;
			     }
			     if (RealRodOfDiscord)
			     {
				     int num249 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 73, npc.velocity.X, npc.velocity.Y, 50, default(Color), 1.2f);
				     Main.dust[num249].noGravity = true;
				     Dust dust2 = Main.dust[num249];
				     dust2.velocity *= 0.3f;
			     }
		    }



		public override void OnKill(NPC npc)
		{

			if (npc.type == 113 && Main.hardMode == false)
			{


				Main.NewText("The desert sands shift frantically.", Color.SandyBrown);



			}
			if (npc.type == NPCID.Retinazer | npc.type == NPCID.Spazmatism | npc.type == NPCID.TheDestroyer | npc.type == NPCID.SkeletronPrime && NPC.downedMechBossAny == false)
			{

				
				Main.NewText("The profaned depths call.", Color.Orange);
				
				   

			}
			if (npc.type == 113 && NPC.downedMoonlord == false)
			{


				Main.NewText("The ruinous winds uncover shards of a long lost kingdom.", Color.IndianRed);



			}
		}




	}





}	