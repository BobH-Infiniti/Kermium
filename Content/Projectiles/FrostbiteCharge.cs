using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;


namespace KermiumMod.Projectiles
{
    public class FrostbiteCharge : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frigid Bolt");




        }


        public override void SetDefaults()
        {

            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.arrow = true;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            AIType = ProjectileID.Bullet;



        }
        public override void AI()
        {
            for (int i = 0; i < 10; i++)
            {
                int num249 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 206, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 1.2f);
                Main.dust[num249].noGravity = true;
                Dust dust2 = Main.dust[num249];
                dust2.velocity *= 0.3f;
               
            }
            
          



        }
       
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) 
        {

            target.AddBuff(BuffID.Frostburn, 300);


        }
       
        public override void OnKill(int timeLeft)
        {
           
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
           
            float num859 = Main.rand.NextFloat() * ((float)Math.PI * 2f);
            var source = Projectile.GetSource_FromThis();
            for (float num860 = 0f; num860 < 1f; num860 += 355f / (678f * (float)Math.PI))
            {
                float f2 = num859 + num860 * ((float)Math.PI * 2f);
                Vector2 velocity = f2.ToRotationVector2() * (4f + Main.rand.NextFloat() * 2f);
                velocity += Vector2.UnitY * -1f;
                int num861 = Projectile.NewProjectile(source, Projectile.Center, velocity, ProjectileID.SapphireBolt, Projectile.damage / 3, 0f, Projectile.owner); //ProjectileID.242 is the High Velocity Bullet
                Projectile projectile = Main.projectile[num861];
                Projectile projectile2 = projectile;
                projectile2.timeLeft -= Main.rand.Next(30);
            }
        }


       


    }
}