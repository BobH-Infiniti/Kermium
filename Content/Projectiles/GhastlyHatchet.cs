using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using YesMod;


namespace YesMod.Projectiles
{
    public class GhastlyHatchet : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ghastly Hatchet");




        }


        public override void SetDefaults()
        {

            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.aiStyle = 3;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            AIType = ProjectileID.PaladinsHammerFriendly;
            Projectile.tileCollide = false;



        }
        public override void AI()
        {
            
           
        }
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {

           
            

        }
        //After the projectile is dead
        public override void Kill(int timeLeft)
        {
           


        }


    }
}