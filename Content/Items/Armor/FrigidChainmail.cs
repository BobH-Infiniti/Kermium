using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;
using static Terraria.Player;
using Terraria.GameContent.Creative;


namespace KermiumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class FrigidChainmail : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Increases critical strike chance by 2%.");
               
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 9000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Generic) += 2;



		}

		

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}