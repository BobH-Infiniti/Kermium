using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace KermiumMod.Items.Weapons
{
	public class AstralCleaver : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("AstralCleaver"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			/* Tooltip.SetDefault("'It came from outer space'" +
                "\nCritical strikes set enemies on fire and grant the player 5 seconds of Lava Immunity."); */
		}

		public override void SetDefaults() 
		{
			Item.damage = 24;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			
		}


		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (hit.Crit)
			{

				target.AddBuff(BuffID.OnFire, 360);
				player.AddBuff(BuffID.ObsidianSkin, 360);
			}
		}



		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.Emerald, 5);
			recipe.AddIngredient(ItemID.Amethyst, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}