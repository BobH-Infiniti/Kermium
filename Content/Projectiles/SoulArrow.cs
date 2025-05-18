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
    public class SoulArrow : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Soul Arrow");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;



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
            Projectile.DamageType = DamageClass.Magic;   
            Projectile.penetrate = 1; 
            Projectile.timeLeft = 40000; 
            Projectile.light = 0.09f;
            Projectile.arrow = true;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Projectile.spriteDirection = Projectile.direction;
        }
        public override void AI()
        {
            for (int i = 0; i < 10; i++)
            {
                int num249 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 29, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 1.2f);
                Main.dust[num249].noGravity = true;
             
                Dust dust2 = Main.dust[num249];
                dust2.velocity *= 0.3f;

            }

        }
       
        
        public override void OnKill(int timeLeft)
        {
           
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.DD2_WitherBeastCrystalImpact, Projectile.position);
        }


        


    }
}