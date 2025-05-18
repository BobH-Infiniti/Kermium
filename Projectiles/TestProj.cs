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
    public class TestProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Test Homing Projectile");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1; // Set the AI style to -1 for custom AI
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 600; // Set the time it lasts for
            Projectile.alpha = 255; // Set the alpha
            Projectile.ignoreWater = true; // Ignore water
            Projectile.tileCollide = true; // Collide with tiles
            Projectile.penetrate = -1; // -1 for unlimited
            Projectile.light = 0.5f; // Set the light level
            AIType = ProjectileID.Bullet; // Set the aiType to a bullet
        }

        public override void AI()
        {
            float speed = 8f; // Set the speed of the projectile
            float turnSpeed = 0.1f; // Set the turning speed of the projectile
            float maxDistance = 1000f; // Set the maximum distance it can travel before stopping

            // Find the closest enemy
            float closestDist = maxDistance;
            NPC target = null;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.CanBeChasedBy() && !npc.friendly)
                {
                    float dist = Vector2.Distance(Projectile.Center, npc.Center);
                    if (dist < closestDist)
                    {
                        closestDist = dist;
                        target = npc;
                    }
                }
            }
            
            // Turn towards the target
            if (target != null)
            {
                Vector2 direction = target.Center - Projectile.Center;
                direction.Normalize();
                Projectile.velocity = (Projectile.velocity * (1 - turnSpeed)) + (direction * speed * turnSpeed);
            }

            // Set the rotation of the projectile to the velocity direction
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

        public override void OnKill(int timeLeft)
        {
          
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


       


    }
}