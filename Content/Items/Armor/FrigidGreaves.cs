using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;


namespace KermiumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class FrigidGreaves : ModItem
	{
		public override void SetStaticDefaults() {
			/* Tooltip.SetDefault("Increases damage by 1%." +
                "\nEnemies take a small amount of damage when striking you."); */
               
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 9000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) += 0.01f;
			player.thorns += 1;


		}

		

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}