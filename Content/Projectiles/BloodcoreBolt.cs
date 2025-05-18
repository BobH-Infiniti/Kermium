using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;


namespace KermiumMod.Projectiles
{
    public class BloodcoreBolt : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bloodcore Bolt");




        }


        public override void SetDefaults()
        {

            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            AIType = ProjectileID.Bullet;



        }
        public override void AI()
        {
            for (int i = 0; i < 1; i++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 235, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }

            float maxDetectRadius = 695f; // The maximum radius at which a projectile can detect a target
            float projSpeed = 20f; // The speed at which the projectile moves towards the target

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
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) //When you hit an NPC
        {

            Player p = Main.player[Projectile.owner];
            int healingAmount = 2; //decrease the value 30 to increase heal, increase value to decrease. Or you can just replace damage/x with a set value to heal, instead of making it based on damage.
            p.statLife += healingAmount;
            p.HealEffect(healingAmount, true);


        }
        //After the projectile is dead
        public override void OnKill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


       


    }
}