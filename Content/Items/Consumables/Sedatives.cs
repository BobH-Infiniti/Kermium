using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KermiumMod.Items.Consumables
{    
    public class Sedatives : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sedatives");
            /* Tooltip.SetDefault("Reduces damage by 10%" +
                "\nIncreases damage reduction by 10%" +
                "\nIncreases defense by 15" +
                "\nNegates effects of agitative pills."); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public int InceptionCD;
		

        public override void SetDefaults()
        {
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.buyPrice(gold: 1);
			Item.buffType = ModContent.BuffType<Buffs.Sedatives>(); 
			Item.buffTime = 18000; 


		}



        public override void AddRecipes()

        {


            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.Daybloom, 3);
            recipe.AddIngredient(ItemID.Deathweed, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();


        }

    }
}