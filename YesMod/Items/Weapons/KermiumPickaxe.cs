using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YesMod.Items.Weapons
{
	public class KermiumPickaxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("AstralCleaver"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("'These are usually only found in ancient ruins'");
               
		}

		public override void SetDefaults() 
		{
			Item.damage = 9;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 10;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.pick = 110;
			Item.knockBack = 4;
			Item.value = 10000;
			
			Item.rare = 2;
			
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			
		}


		



		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.KermiumBar>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}