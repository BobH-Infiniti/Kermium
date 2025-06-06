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
    public class BigRaindrop : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Divine Blade");




        }


        public override void SetDefaults()
        {

            Projectile.width = 18;
            Projectile.height = 40;
            Projectile.aiStyle = 2;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            



        }
        public override void AI()
        {
            
           
        }
       
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) 
        {

           
            float num859 = Main.rand.NextFloat() * ((float)Math.PI * 2f);
            var source = Projectile.GetSource_FromThis();
            for (float num860 = 0f; num860 < 1f; num860 += 355f / (678f * (float)Math.PI))
            {
                float f2 = num859 + num860 * ((float)Math.PI * 2f);
                Vector2 velocity = f2.ToRotationVector2() * (4f + Main.rand.NextFloat() * 2f);
                velocity += Vector2.UnitY * -1f;
                int num861 = Projectile.NewProjectile(source , Projectile.Center, velocity, ModContent.ProjectileType<Projectiles.SmallRaindrop>(), damageDone / 3, 0f, Projectile.owner); //ProjectileID.242 is the High Velocity Bullet
                Projectile projectile = Main.projectile[num861];
                Projectile projectile2 = projectile;
                projectile2.timeLeft -= Main.rand.Next(30);
            }

        }
       
        public override void OnKill(int timeLeft)
        {
           
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


       


    }
}