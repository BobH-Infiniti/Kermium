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
    public class ChargedFrostbiteBolt : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Enhanced Frigid Bolt");




        }


        public override void SetDefaults()
        {

            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 2;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            AIType = ProjectileID.Bullet;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.arrow = true;



        }
        public override void AI()
        {
            for (int i = 0; i < 10; i++)
            {
                int num249 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 92, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 1.2f);
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
            SoundEngine.PlaySound(SoundID.Item28, Projectile.position);
        }


       


    }
}