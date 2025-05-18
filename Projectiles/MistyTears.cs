using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using KermiumMod;


namespace KermiumMod.Projectiles
{
    public class MistyTears : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Misty Tears");




        }


        public override void SetDefaults()
        {

            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            AIType = ProjectileID.Bullet;



        }
        public override void AI()
        {
            for (int i = 0; i < 10; i++)
            {
                int num249 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 91, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 1.2f);
                Main.dust[num249].noGravity = true;                                                                                     //76

                Dust dust2 = Main.dust[num249];
                dust2.velocity *= 0.3f;

            }

            float maxDetectRadius = 100f; 
            float projSpeed = 16f; 

         
            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;

           
            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); ;

            Projectile.spriteDirection = Projectile.direction;
            Lighting.AddLight(Projectile.Center, 0.224f, 1f, 0.78f);
        }


        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;

           
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

           
            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
               
                if (target.CanBeChasedBy())
                {
                   
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                  
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;

        }


       
       
        public override void OnKill(int timeLeft)
        {
          
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


       


    }
}