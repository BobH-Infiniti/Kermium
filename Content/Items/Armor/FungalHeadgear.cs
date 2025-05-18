using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace KermiumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class FungalHeadgear : ModItem
	{
		public override void SetStaticDefaults() {
			/* Tooltip.SetDefault("Increases melee damage by 14%." +
                "\nIncreases melee speed by 7%."); */
               
		}



		

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = ItemRarityID.Pink;
			Item.defense = 32;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) += 0.14f;
			



		}

		public int FASetCD;

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<Items.Armor.FungalBreastplate>() && legs.type == ItemType<Items.Armor.FungalLeggings>();
		}


		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Melee damage is increased by 8%" +
                "\nYou occasionally spew a spread of homing mushrooms at nearby enemies";
			player.GetDamage(DamageClass.Melee) += 0.08f;


			var source = player.GetSource_Accessory(this.Item);
			if (Main.myPlayer != player.whoAmI)
			{
				return;
			}
			FASetCD++;
			if (FASetCD <= 80)
			{
				return;
			}
			FASetCD = 0;
			int damage = 60;
			float knockBack = 4f;
			float num = 640f;
			NPC nPC = null;
			for (int i = 0; i < 200; i++)
			{
				NPC nPC2 = Main.npc[i];
				if (nPC2 != null && nPC2.active && nPC2.CanBeChasedBy(player) && Collision.CanHit(player, nPC2))
				{
					float num2 = Vector2.Distance(nPC2.Center, player.Center);
					if (num2 < num)
					{
						num = num2;
						nPC = nPC2;
					}
				}
			}
			if (nPC != null)
			{
				Vector2 v = nPC.Center - player.Center;
				v = v.SafeNormalize(Vector2.Zero) * 9;

				Projectile.NewProjectile(source, player.Center.X, player.Center.Y, v.X, v.Y, ModContent.ProjectileType<Projectiles.GMushroom>(), damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(source, player.Center.X, player.Center.Y, v.X , v.Y + 1, ModContent.ProjectileType<Projectiles.GMushroom>(), damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(source, player.Center.X, player.Center.Y, v.X, v.Y - 1, ModContent.ProjectileType<Projectiles.GMushroom>(), damage, knockBack, player.whoAmI);
				FASetCD = 0;
			}

		}
		//ModContent.ProjectileType<Projectiles.MushroomBolt>()
		public override void AddRecipes()
		{
			
		}
	}
}