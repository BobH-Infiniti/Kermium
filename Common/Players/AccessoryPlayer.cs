using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameInput;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.UI;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using KermiumMod;
using static Terraria.Player;
using static KermiumMod.Items.Weapons.BelowZero;
using KermiumMod.Systems;

namespace KermiumMod
{
	public class AccessoryPlayer : ModPlayer
	{
		public bool TarotCD;
		public bool Intuition;
		public bool Duty;
		public bool Leadership;
		public bool Hope;
		public bool Trauma;
		public bool Enlightenment;

		
		public int EnlightenedStarAmount;
		public int EnlightenedStarPos;
		

		public bool LovePotionAcc;
		public bool Granoot;
		public bool TribalPendant;
		public bool HolyVirtue;
		public bool PermafrostPendant;
		public bool DivineAcorn;
		
		public bool JawsumAcc;
		public bool LizardFetish;
		public bool BrokenNazar;
		public bool GoryTendril;
		public bool DriedArcanum;
		public bool BlazingRanger;
		public bool EngorgedDoll;
		public bool WorldCluster;

		public int Frenzy;
		public int FrostyCD;
		public int LovePotionAccCooldown;
		public int Sin;
		public int SinCD;
		public int SinBurstCD;
		public int PersCount;
		

		
		
		public override void ResetEffects()
		{
			TarotCD = false;
			Intuition = false;
			Leadership = false;
			LovePotionAcc = false;
			Granoot = false;
			TribalPendant = false;
			HolyVirtue = false;
			PermafrostPendant = false;
			DivineAcorn = false;
			Hope = false;
			Trauma = false;
			JawsumAcc = false;
			LizardFetish = false;
			BrokenNazar = false;
			GoryTendril = false;
			DriedArcanum = false;
			BlazingRanger = false;
			EngorgedDoll = false;
			WorldCluster = false;
			Duty = false;
			Enlightenment = false;

			
		}

		public void Update(int i)
		{
			if (LovePotionAcc && LovePotionAccCooldown > 0)
			{
				LovePotionAccCooldown--;

			}
			if (PermafrostPendant && FrostyCD > 0)
			{
				FrostyCD--;

			}
			

		}
		

		public override void UpdateEquips()
		{
			Player player = Main.player[0];
			

			
			

			if (JawsumAcc)
            {
				player.GetArmorPenetration(DamageClass.Generic) += 6;
				player.accFlipper = true;
				player.gills = true;
				if (player.wet)
                {
					player.GetDamage(DamageClass.Generic) += 0.15f;
				}
				
			}
			if (Duty)
			{


				player.endurance += 0.02f;
				player.GetArmorPenetration(DamageClass.Generic) += 3;
				if (Keybinds.TarotKeybind.JustPressed && !TarotCD)
				{
					Main.NewText(PersCount * 10);
					player.statLife +=  PersCount * 10;
					PersCount = 0;
					player.AddBuff(ModContent.BuffType<Buffs.TarotCD>(), 2700);

				}

			}
			if (Leadership)
            {
				if (Keybinds.TarotKeybind.JustPressed && !TarotCD)
				{
					
					player.AddBuff(ModContent.BuffType<Buffs.LeadershipBuff>(), 600);
					player.AddBuff(ModContent.BuffType<Buffs.TarotCD>(), 1800);



				}


			}
			if (Enlightenment)
            {

				var source = Player.GetSource_Accessory(player.HeldItem);
				if (Keybinds.TarotKeybind.JustPressed && !TarotCD)
                {
					
					Projectile.NewProjectile(source, player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.EnlightenedStar>(), 50, 15f, player.whoAmI);
					
					return;
				}
					

			}
			if (LizardFetish)
            {
				player.lifeRegen += 1;
				if (player.statLife < player.statLifeMax2 / 2 + 1)
				{
					player.GetDamage(DamageClass.Generic) += 0.1f;
					player.GetArmorPenetration(DamageClass.Generic) += 1;
					if (player.statLife < player.statLifeMax2 / 10 + 1)
                    {
						player.GetDamage(DamageClass.Generic) += 0.4f;
						player.GetArmorPenetration(DamageClass.Generic) += 5;
					}
				}
			}
			if (BrokenNazar)
            {
				player.GetDamage(DamageClass.Generic) += 0.3f;
			}
			if (GoryTendril)
            {
				player.moveSpeed += 0.15f;
				player.GetDamage(DamageClass.Summon) += 0.7f;

			}
			if (DriedArcanum)
            {
				player.thorns = 1;
				player.GetAttackSpeed(DamageClass.Generic) += 0.04f;
			}





			if (PermafrostPendant && FrostyCD > 0)
			{
				FrostyCD--;

			}
			if (WorldCluster && FrostyCD > 0)
			{
				FrostyCD--;

			}
			if (EngorgedDoll && SinCD > 0)
			{
				SinCD--;

			}
			if (EngorgedDoll && SinBurstCD > 0)
			{
				SinBurstCD--;

			}
			

		}
	
		public override void PostHurt(Player.HurtInfo info)
		{
			
			Player player = Main.player[0];
			Vector2 center = player.Center;
			
			if (LovePotionAcc && LovePotionAccCooldown == 0)
            {
				
				float num859 = Main.rand.NextFloat() * ((float)Math.PI * 2f);
				var source = Player.GetSource_Accessory(player.HeldItem);
				for (float num860 = 0f; num860 < 1f; num860 += 355f / (678f * (float)Math.PI))
				{
					float f2 = num859 + num860 * ((float)Math.PI * 2f);
					Vector2 velocity = f2.ToRotationVector2() * (4f + Main.rand.NextFloat() * 2f);
					velocity += Vector2.UnitY * -1f;
					int num861 = Projectile.NewProjectile(source, center,  velocity, 370, 200, 0f, player.whoAmI); //ProjectileID.370 is the Love Potion.
					Projectile projectile = Main.projectile[num861];
					Projectile projectile2 = projectile;
					projectile2.timeLeft -= Main.rand.Next(30);
				}
				
			}
			if (Trauma && info.Damage <= 200)
            {
				player.AddBuff(ModContent.BuffType<Buffs.DivineGift>(), 500);
				float num859 = Main.rand.NextFloat() * ((float)Math.PI * 2f);
				var source = Player.GetSource_Accessory(player.HeldItem);
				for (float num860 = 0f; num860 < 1f; num860 += 355f / (678f * (float)Math.PI))
				{
					float f2 = num859 + num860 * ((float)Math.PI * 2f);
					Vector2 velocity = f2.ToRotationVector2() * (4f + Main.rand.NextFloat() * 2f);
					velocity += Vector2.UnitY * -1f;
					int num861 = Projectile.NewProjectile(source, center, velocity * 3, 296, 200, 0f, player.whoAmI); //ProjectileID.296 is the Inferno Blast.
					Projectile projectile = Main.projectile[num861];
					Projectile projectile2 = projectile;
					projectile2.timeLeft -= Main.rand.Next(30);
				}
			}
			if (HolyVirtue)
			{
				float num859 = Main.rand.NextFloat() * ((float)Math.PI * 2f);
				var source = Player.GetSource_Accessory(player.HeldItem);
				for (float num860 = 0f; num860 < 1f; num860 += 355f / (678f * (float)Math.PI))
				{
					float f2 = num859 + num860 * ((float)Math.PI * 2f);
					Vector2 velocity = f2.ToRotationVector2() * (4f + Main.rand.NextFloat() * 2f);
					velocity += Vector2.UnitY * -1f;
					int num861 = Projectile.NewProjectile(source, center, velocity * 2, 494, 150, 0f, player.whoAmI); //ProjectileID.494 is the Crystal Charge.
					Projectile projectile = Main.projectile[num861];
					Projectile projectile2 = projectile;
					projectile2.timeLeft -= Main.rand.Next(30);
				}
			}
			if (DivineAcorn && info.Damage > 20)
            {
				player.statLife += 2;
				player.AddBuff(ModContent.BuffType<Buffs.DivineGift>(), 300);
				
			}
			if (WorldCluster && !DivineAcorn && info.Damage > 5)
			{
				player.statLife += 5;
				player.AddBuff(ModContent.BuffType<Buffs.DivineGift>(), 500);

			}
			if (BrokenNazar)
            {
				player.AddBuff(BuffID.Stoned, 30);
				player.statLife -= (int)info.Damage / 2;
				CombatText.NewText(player.Hitbox, Color.Purple, (int)info.Damage / 2);
				player.immuneTime /= 2 ;

			}
			if (Duty && PersCount < 5)
            {
				PersCount += 1;
            }
				
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)/* tModPorter If you don't need the Item, consider using ModifyHitNPC instead */
		{

			

			if ((proj.friendly && Intuition && !proj.noEnchantments && hit.Crit))
			{

				damageDone += 4;

			}
			if ((proj.friendly && Granoot && !proj.noEnchantments && proj.DamageType == DamageClass.Ranged))
			{
				
				target.AddBuff(ModContent.BuffType<Buffs.GraniteCurse>(), 50 * Main.rand.Next(5, 15), false);
			}
			if ((proj.friendly && TribalPendant && !proj.noEnchantments && proj.DamageType == DamageClass.Ranged && hit.Crit))
			{

				target.AddBuff(BuffID.Poisoned, 90 * Main.rand.Next(5, 15), false);
			}
			if ((proj.friendly && TribalPendant && !proj.noEnchantments && proj.DamageType == DamageClass.Magic && hit.Crit))
			{

				target.AddBuff(BuffID.Ichor, 30 * Main.rand.Next(5, 15), false);
			}
			if ((proj.friendly && TribalPendant && !proj.noEnchantments && proj.DamageType == DamageClass.Melee && hit.Crit))
			{

				target.AddBuff(BuffID.OnFire, 80 * Main.rand.Next(5, 15), false);
			}
			if ((proj.friendly && TribalPendant && !proj.noEnchantments && proj.DamageType == DamageClass.Summon))
			{

				target.AddBuff(BuffID.Frostburn, 20 * Main.rand.Next(5, 15), false);
			}
			if ((proj.friendly && PermafrostPendant && !proj.noEnchantments && proj.DamageType == DamageClass.Magic && hit.Crit && FrostyCD == 0))
			{

				FrostyCD += 23;
				float num859 = Main.rand.NextFloat() * ((float)Math.PI * 2f);
				var source = proj.GetSource_FromThis();
				for (int num410 = 0; num410 < 3; num410++)
				{
					float num411 = (0f - proj.velocity.X) * (float)Main.rand.Next(2, 5) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
					float num412 = (0f - Math.Abs(proj.velocity.Y)) * (float)Main.rand.Next(3, 5) * 0.01f + (float)Main.rand.Next(-20, 5) * 0.4f;
					Terraria.Projectile.NewProjectile(source, proj.Center.X + num411, proj.Center.Y + num412, num411, num412, ModContent.ProjectileType<Projectiles.PermafrostShard>(), (int)((double)proj.damage / 1.5), 0f, proj.owner);

				}
				
			}
			if ((proj.friendly && WorldCluster && !proj.noEnchantments && hit.Crit && FrostyCD == 0))
			{

				FrostyCD += 20;
				float num859 = Main.rand.NextFloat() * ((float)Math.PI * 2f);
				var source = proj.GetSource_FromThis();
				for (int num410 = 0; num410 < 3; num410++)
				{
					float num411 = (0f - proj.velocity.X) * (float)Main.rand.Next(2, 5) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
					float num412 = (0f - Math.Abs(proj.velocity.Y)) * (float)Main.rand.Next(3, 5) * 0.01f + (float)Main.rand.Next(-20, 5) * 0.4f;
					Terraria.Projectile.NewProjectile(source, proj.Center.X + num411, proj.Center.Y + num412, num411, num412, ModContent.ProjectileType<Projectiles.PermafrostShard>(), (int)((double)proj.damage / 1.2), 0f, proj.owner);

				}

			}
			if ((proj.friendly && BlazingRanger && !proj.noEnchantments && proj.DamageType == DamageClass.Ranged))
			{

				target.AddBuff(ModContent.BuffType<Buffs.AncientFlame>(), 50 * Main.rand.Next(5, 15), false);
				Player.statLife += (int)0.5;
			}
			if ((proj.friendly && EngorgedDoll && !proj.noEnchantments &&  SinCD == 0))
			{

				SinCD += 120;
				Sin += 1;
				if (Sin <= 10)
                {
					CombatText.NewText(Player.Hitbox, Color.Firebrick, Sin);
				}
				
				if (Sin > 10)
                {
					CombatText.NewText(Player.Hitbox, Color.Firebrick, " ");
				}

				

			}
			if ((proj.friendly && EngorgedDoll && !proj.noEnchantments && SinBurstCD == 0 && Sin == 11))
			{

				
				float num859 = Main.rand.NextFloat() * ((float)Math.PI * 2f);
				var source = proj.GetSource_FromThis();
				for (float num860 = 0f; num860 < 1f; num860 += 355f / (678f * (float)Math.PI))
				{
					float f2 = num859 + num860 * ((float)Math.PI * 2f);
					Vector2 velocity = f2.ToRotationVector2() * (4f + Main.rand.NextFloat() * 2f);
					velocity += Vector2.UnitY * -1f;
					int num861 = Terraria.Projectile.NewProjectile(source, proj.Center, velocity / 2, 307, damageDone, 0f, proj.owner); //ProjectileID.242 is the Tiny Eater
					Projectile projectile = Main.projectile[num861];
					Projectile projectile2 = projectile;
					projectile2.timeLeft -= Main.rand.Next(30);
					SoundEngine.PlaySound(SoundID.DD2_WyvernScream, proj.Center);
				}
				SinCD += 1200;
				SinBurstCD += 1200;
				Sin = 0;


			}

		}


		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
			bool retVal = true;
			Player player = Main.player[0];
			if (player.statLife <= 0)
            {
				if (Hope && player.whoAmI == Main.myPlayer && retVal && player.FindBuffIndex(ModContent.BuffType<Buffs.HopeRevival>()) == -1)
				{
					player.statLife += 20;
					player.HealEffect(20);
					player.immune = true;
					player.immuneTime = 180;
					SoundEngine.PlaySound(SoundID.DD2_BetsyScream, player.position);
					player.hurtCooldowns[0] += 180;
					player.hurtCooldowns[1] += 180;
					Main.NewText(player.name +" has denied death", Color.Green);
					CombatText.NewText(player.Hitbox, Color.Lime, "I shall move forward!");
					player.AddBuff(ModContent.BuffType<Buffs.HopeRevival>(), 10800);
					player.AddBuff(ModContent.BuffType<Buffs.DivineGift>(), 300);
					retVal = false;
				}
				

			}
			
			return retVal;

		}



		







	}
}