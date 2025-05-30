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
    public class FervorBolt : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fervorous Charge");




        }


        public override void SetDefaults()
        {

            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.arrow = true;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            AIType = ProjectileID.Bullet;



        }
        public override void AI()
        {
            Player player = Main.player[0];
            for (int i = 0; i < 10; i++)
            {
                int num249 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 115, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 1.2f);
                Main.dust[num249].noGravity = true;
                Dust dust2 = Main.dust[num249];
                dust2.velocity *= 0.3f;





            }

            float maxDetectRadius = 200f; // The maximum radius at which a projectile can detect a target
            float projSpeed = 10f; // The speed at which the projectile moves towards the target

            // Trying to find NPC closest to the projectile
            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;

            // If found, change the velocity of the projectile and turn it in the direction of the target
            // Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); ;

            Projectile.spriteDirection = Projectile.direction;



        }


        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;

            // Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            // Loop through all NPCs(max always 200)
            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                // Check if NPC able to be targeted. It means that NPC is
                // 1. active (alive)
                // 2. chaseable (e.g. not a cultist archer)
                // 3. max life bigger than 5 (e.g. not a critter)
                // 4. can take damage (e.g. moonlord core after all it's parts are downed)
                // 5. hostile (!friendly)
                // 6. not immortal (e.g. not a target dummy)
                if (target.CanBeChasedBy())
                {
                    // The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    // Check if it is within the radius
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
            SoundEngine.PlaySound(SoundID.NPCHit20, Projectile.position);
           
           
        }


       


    }
}