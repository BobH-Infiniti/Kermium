using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace YesMod.Items.Weapons
{
	public class GhastlyHatchet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
			Tooltip.SetDefault("'The wrath of those lost to time is sealed in this vessel'" +
                "\nShoots returning hatchets that pierce walls.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.damage = 140;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 0.3f;
			Item.value = 10000;
			Item.rare = 2;
			Item.shoot = ModContent.ProjectileType<Projectiles.GhastlyHatchet>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 20f;
			Item.noUseGraphic = true;

		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{


			
			target.AddBuff(BuffID.Poisoned, 360);
				
			
		}



		
	}
}