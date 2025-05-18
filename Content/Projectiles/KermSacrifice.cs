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
    public class KermSacrifice : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Kermian Stream");




        }


        public override void SetDefaults()
        {

            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 29;
            Projectile.DamageType = ModContent.GetInstance<DamageClasses.SacrificialClass>();
            Projectile.penetrate = 1;
            Projectile.arrow = true;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            AIType = ProjectileID.ThunderStaffShot;



        }
        public override void AI()
        {
            Player player = Main.player[0];
            for (int i = 0; i < 10; i++)
            {
                int num249 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 74, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 1.2f);
                Main.dust[num249].noGravity = true;
                Dust dust2 = Main.dust[num249];
                dust2.velocity *= 0.3f;





            }

          
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); ;

            Projectile.spriteDirection = Projectile.direction;



        }


        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) 
        {

            target.AddBuff(ModContent.BuffType<Buffs.KermiumAffliction>(), 300);


        }
       
        public override void OnKill(int timeLeft)
        {
            
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.NPCHit20, Projectile.position);
           
           
        }


       


    }
}