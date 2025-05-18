using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using KermiumMod;


namespace KermiumMod.Projectiles
{
    public class HoarfrostBullet : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hoarfrost Bullet");




        }


        public override void SetDefaults()
        {

            Projectile.width = 2;
            Projectile.height = 20;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            AIType = ProjectileID.Bullet;



        }
        public override void AI()
        {
            
           
        }
       
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) 
        {
            if (hit.Crit) {
                Projectile.penetrate += 1;
                Projectile.velocity *= 2;

                SoundEngine.PlaySound(SoundID.DD2_WitherBeastCrystalImpact, Projectile.position); 
            }
          
            
            

        }
       
        public override void OnKill(int timeLeft)
        {
           
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item11, Projectile.position);

        }


       


    }
}