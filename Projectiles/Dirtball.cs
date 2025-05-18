using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;


namespace KermiumMod.Projectiles
{
    public class Dirtball : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dirtball");




        }


        public override void SetDefaults()
        {
            
            Projectile.width = 14; 
            Projectile.height = 14;  
            Projectile.aiStyle = 2;
            Projectile.friendly = true;  
            Projectile.hostile = false;
            Projectile.tileCollide = true; 
            Projectile.ignoreWater = false; 
            Projectile.DamageType = DamageClass.Ranged;  
            Projectile.penetrate = 1;
            Projectile.timeLeft = 40000;
            
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Projectile.spriteDirection = Projectile.direction;
        }
       
      
        public override void OnKill(int timeLeft)
        {
            
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


      


    }
}