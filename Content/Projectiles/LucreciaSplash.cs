using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;
using Terraria.GameContent.Creative;


namespace KermiumMod.Projectiles
{
    public class LucreciaSplash : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lucrecia Splash");
            



        }


        public override void SetDefaults()
        {
            
            Projectile.width = 14;  
            Projectile.height = 28;  
            Projectile.aiStyle = 1; 
            Projectile.friendly = true; 
            Projectile.hostile = false;
            Projectile.tileCollide = true; 
            Projectile.ignoreWater = false; 
            Projectile.DamageType = DamageClass.Melee;   
            Projectile.penetrate = 1; 
            Projectile.timeLeft = 40000; 
            Projectile.light = 0.09f; 
            
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Projectile.spriteDirection = Projectile.direction;
        }
        
       
       
        public override void OnKill(int timeLeft)
        {
            var source = Projectile.GetSource_FromThis();

            for (int num410 = 0; num410 < 6; num410++)
            {
                float num411 = (0f - Projectile.velocity.X) * (float)Main.rand.Next(20, 50) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
                float num412 = (0f - Math.Abs(Projectile.velocity.Y)) * (float)Main.rand.Next(30, 50) * 0.01f + (float)Main.rand.Next(-20, 5) * 0.4f;
                Projectile.NewProjectile(source, Projectile.Center.X + num411, Projectile.Center.Y + num412, num411, num412, 22, (int)((double)Projectile.damage * 2), 0f, Projectile.owner);

            } 
           Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Drip, Projectile.position);
        }


        
        


    }
}