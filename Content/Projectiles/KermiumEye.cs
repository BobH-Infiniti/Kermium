using  System;
using Microsoft.Xna.Framework;
using  Microsoft.Xna.Framework.Graphics;
using  Terraria;
using  Terraria.Audio;
using  Terraria.GameContent;
using  Terraria.ID;
using Terraria.DataStructures;
using  Terraria.ModLoader;
using KermiumMod;


namespace KermiumMod.Projectiles
{
    public class KermiumEye : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eye of Oblivion");




        }


        public override void SetDefaults()
        {

            Projectile.width = 16;
            Projectile.height = 32;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            AIType = ProjectileID.Bullet;
          
        }
        public override void AI()
        {
            float maxDetectRadius = 400f; // The maximum radius at which a projectile can detect a target
            float projSpeed = 25f; // The speed at which the projectile moves towards the target

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

        // Finding the closest NPC to attack within maxDetectDistance range
        // If not found then returns null
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
       
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) 
        {

            target.AddBuff(ModContent.BuffType<Buffs.KermiumAffliction>(), 300);

        }
       
        public override void OnKill(int timeLeft)
        {
            
            
            
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
           
        }


       


    }
}