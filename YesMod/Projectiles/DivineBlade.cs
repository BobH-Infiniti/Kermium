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
    public class DivineBlade : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Blade");




        }


        public override void SetDefaults()
        {

            Projectile.width = 18;
            Projectile.height = 40;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            AIType = ProjectileID.Bullet;



        }
        public override void AI()
        {
            
           
        }
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {

           
            float num859 = Main.rand.NextFloat() * ((float)Math.PI * 2f);
            var source = Projectile.GetProjectileSource_FromThis();
            for (float num860 = 0f; num860 < 1f; num860 += 355f / (678f * (float)Math.PI))
            {
                float f2 = num859 + num860 * ((float)Math.PI * 2f);
                Vector2 velocity = f2.ToRotationVector2() * (4f + Main.rand.NextFloat() * 2f);
                velocity += Vector2.UnitY * -1f;
                int num861 = Projectile.NewProjectile(source , Projectile.Center, velocity, 242, damage / 3, 0f, Projectile.owner); //ProjectileID.242 is the High Velocity Bullet
                Projectile projectile = Main.projectile[num861];
                Projectile projectile2 = projectile;
                projectile2.timeLeft -= Main.rand.Next(30);
            }

        }
        //After the projectile is dead
        public override void Kill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


       


    }
}