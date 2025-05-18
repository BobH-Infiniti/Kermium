using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;


namespace KermiumMod.Projectiles
{
    public class BloodyStrike : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bloody Strike");




        }


        public override void SetDefaults()
        {

            Projectile.width = 16;
            Projectile.height = 28;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            
        }
        
      
        public override void OnKill(int timeLeft)
        {
           
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


       


    }
}