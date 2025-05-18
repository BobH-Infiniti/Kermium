using System;
using System.Collections.Generic;
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
    public class SmallRaindrop : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            




        }

        private int StardustTimer = 80;

        public override void SetDefaults()
        {

            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.timeLeft = 2700;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 0;
           




        }
        public override void AI()
        {


            
            var source = Projectile.GetSource_FromThis();
            Player player = Main.player[Projectile.owner];
            float maxDetectRadius = 695f; // The maximum radius at which a projectile can detect a target
            float projSpeed = 20f; // The speed at which the projectile moves towards the target

            // Trying to find NPC closest to the projectile
            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            
            if (closestNPC == null)
                return;
            if (!player.active || player.dead)
            {
                Projectile.Kill();
                return;
            }
            if (Projectile.frameCounter == 0)
            {
                Projectile.frameCounter = 1;
                Projectile.frame = Main.rand.Next(12);
                Projectile.rotation = Main.rand.NextFloat() * ((float)Math.PI * 2f);
            }
            Projectile.rotation += (float)Math.PI / 200f;

            float f = (player.miscCounterNormalized * 6f) * ((float)Math.PI * 2f);
            float scaleFactor = 24f * 6f;
            Vector2 vector = closestNPC.position - closestNPC.oldPosition;
            Projectile.Center += vector;
            Vector2 value = f.ToRotationVector2();
            Projectile.localAI[0] = value.Y;
            Vector2 value2 = closestNPC.Center + value * new Vector2(3f, 3f) * scaleFactor;
            Projectile.Center = Vector2.Lerp(Projectile.Center, value2, 0.01f);

         

            if (StardustTimer > 0)
            {
                StardustTimer--;

            }
            if (StardustTimer == 0)
            {
                
               
                Projectile.Kill();
            }

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
        private void AI_GetMyGroupIndexAndFillBlackList(List<int> blackListedTargets, out int index, out int totalIndexesInGroup)
        {
            index = 0;
            totalIndexesInGroup = 0;
            for (int i = 0; i < 1000; i++)
            {

                Projectile projectile = Main.projectile[i];
                if (projectile.active && projectile.owner == projectile.owner && projectile.type == projectile.type && (projectile.type != 759 || projectile.frame == Main.projFrames[projectile.type] - 1))
                {
                    if (projectile.whoAmI > i)
                    {
                        index++;
                    }
                    totalIndexesInGroup++;
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) //When you hit an NPC
        {



        }
        //After the projectile is dead
        public override void OnKill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


       


    }
}