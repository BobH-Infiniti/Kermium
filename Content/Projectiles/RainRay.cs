using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;


namespace KermiumMod.Projectiles
{
    public class RainRay : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bloodcore Bolt");




        }


        public override void SetDefaults()
        {

            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            AIType = ProjectileID.Bullet;
            Projectile.extraUpdates = 100;
            



        }
        public override void AI()
        {

           

            for (int num352 = 0; num352 < 4; num352++)
            {
                Vector2 position2 = Projectile.position;
                position2 -= Projectile.velocity * ((float)num352 * 0.25f);
                Projectile.alpha = 255;
                int num353 = Dust.NewDust(position2, 1, 1, 15);
                Main.dust[num353].position = position2;
                Main.dust[num353].position.X += Projectile.width / 2;
                Main.dust[num353].position.Y += Projectile.height / 2;
                Main.dust[num353].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                Dust dust = Main.dust[num353];
                dust.velocity *= 0.2f;
            }
            return;
            

            Projectile.spriteDirection = Projectile.direction;

        }


       
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) //When you hit an NPC
        {

           


        }
        //After the projectile is dead
        public override void OnKill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


       


    }
}