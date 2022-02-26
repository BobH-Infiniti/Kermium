using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace YesMod.Items.Weapons
{
    public class FrozenKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Knife");
            Tooltip.SetDefault("'´This type of knife was commonly used in occult rituals.'" +
                "'Throws a knife that follows the cursor and inflicts 'Frostburn'.");
        }

        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.shootSpeed = 13.69f;
            Item.width = 24;
            Item.height = 36;
            Item.useTime = 20;
            Item.useAnimation = 17;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.autoReuse = false;
            Item.value = 3000;
            Item.rare = 3;
            Item.noUseGraphic = true;
            Item.maxStack = 1;
            Item.UseSound = SoundID.Item1;
            Item.channel = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.FrozenKnife>();
           


           
            Item.autoReuse = false;
        }

       

       
    }
}
