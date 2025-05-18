using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace KermiumMod.Items.Weapons
{
	public class SolarGlaives : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
			/* Tooltip.SetDefault("'The wrath of those lost to time is sealed in this vessel'" +
                "\nThrow glaives that explode on hit, critical hits deal much more damage and emit a short ranged fireball on hit."); */
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
			Item.rare = 6;
			Item.shoot = ModContent.ProjectileType<Projectiles.SolarGlaive>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 20f;
			Item.noUseGraphic = true;

		}


		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{


			
			
				
			
		}



		
	}
}