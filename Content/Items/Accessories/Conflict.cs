using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories   
{
    
    public class Conflict : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Conflict");
            /* Tooltip.SetDefault("Increases melee damage by 10%" +
                "\n'The conflict and suspicions never waned until the final day.'"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
    
        

        public override void SetDefaults()
        {
            Item.width = 30;   
            Item.height = 42;    
            Item.value = Item.buyPrice(0, 15, 60, 20); 
            Item.rare = 4;          
            Item.accessory = true; 
           
           

        }
        public override void UpdateAccessory(Player player,bool hideVisual) 
        {
            
           
            player.wingTimeMax += 50;




        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.EmptyTarotCard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 5);
            recipe.AddIngredient(ItemID.SoulofFlight, 20);
            recipe.AddIngredient(ItemID.SoulofNight, 30);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }


    }
}