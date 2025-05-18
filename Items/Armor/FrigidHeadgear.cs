using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace KermiumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class FrigidHeadgear : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Increases melee damage by 4%.");
               
		}



		public int IcyCD;

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) += 0.04f;



		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<Items.Armor.FrigidChainmail>() && legs.type == ItemType<Items.Armor.FrigidGreaves>();
		}


		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Damage reduction is increased by 2%" +
                "\nDouble tapping DOWN restores 25 HP.";
			player.endurance += 0.02f;

			if (IcyCD > 0)
			{
				IcyCD--;
			}
			if (player.whoAmI != Main.myPlayer)
				return;


			if (player.controlDown && player.releaseDown && player.doubleTapCardinalTimer[0] > 0 && player.doubleTapCardinalTimer[0] != 15 && IcyCD == 0)
			{
				
				
					IcyCD = 3600;
					SoundEngine.PlaySound(SoundID.Item120, player.position);
					player.AddBuff(ModContent.BuffType<Buffs.FrigidCD>(), 3600);
				    CombatText.NewText(player.Hitbox, Color.Cyan, "You restored 25 HP");
				    player.statLife += 25;




			}



		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}