using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;


namespace KermiumMod.Projectiles
{
    public class Bass : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bass");




        }


        public override void SetDefaults()
        {
            
            Projectile.width = 16; 
            Projectile.height = 16;  
            Projectile.aiStyle = 1;
            Projectile.friendly = true; 
            Projectile.hostile = false;
            Projectile.tileCollide = true; 
            Projectile.ignoreWater = true; 
            Projectile.DamageType = DamageClass.Ranged;   
            Projectile.penetrate = 1;
            Projectile.timeLeft = 40000;
            Projectile.light = 0.9f; 
            Projectile.arrow = true;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Projectile.spriteDirection = Projectile.direction;
        }
        public override void AI()
        {
           
           
        }
       
       
        
        public override void OnKill(int timeLeft)
        {
            
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.NPCHit20, Projectile.position);
        }


        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            
            target.AddBuff(BuffID.Wet, 360);
        }


    }
}