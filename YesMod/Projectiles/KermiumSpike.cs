using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;
using YesMod;


namespace YesMod.Projectiles
{
    public class KermiumSpike : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kermium Spike");




        }


        public override void SetDefaults()
        {

            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            AIType = ProjectileID.Bullet;

        }
        public override void AI()
        {
            //red | green| blue
           
        }
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {

           

        }
        //After the projectile is dead
        public override void Kill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


       


    }
}