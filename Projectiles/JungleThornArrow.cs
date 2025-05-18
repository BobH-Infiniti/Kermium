using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;


namespace KermiumMod.Projectiles
{
    public class JungleThornArrow : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            




        }


        public override void SetDefaults()
        {
            
            Projectile.width = 8;  
            Projectile.height = 8;  
            Projectile.aiStyle = 1; 
            Projectile.friendly = true;  
            Projectile.hostile = false;
            Projectile.tileCollide = true; 
            Projectile.ignoreWater = false; 
            Projectile.DamageType = DamageClass.Ranged;   
            Projectile.penetrate = -1; 
            Projectile.timeLeft = 40000; 
            Projectile.light = 0f;
            Projectile.arrow = true;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Projectile.spriteDirection = Projectile.direction;
            //Projectile.usesLocalNPCImmunity = true;
            //Projectile.localNPCHitCooldown = 0;
            

        }
       
      
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) 
        {

            target.AddBuff(BuffID.Poisoned, 360);
            //if (target.life > 0)
            //{
               // Projectile.velocity *= -1;
            //} 
                
            

        }

        public override void OnKill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


        


    }
}