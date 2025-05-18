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
    public class PlaceholderProjectile : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            




        }

        private int StardustTimer;

        public override void SetDefaults()
        {

            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.timeLeft = 2700;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = 0;
           




        }
        public override void AI()
        {



            var source = Projectile.GetSource_FromThis();
            Player player = Main.player[Projectile.owner];
            //Projectile.Center = player.Center;
            if (Projectile.ai[0] > 0f)
            {
                float offset = ((Projectile.ai[0] - 1f) / 2);
                float rotation = 900f / 300f + offset;
                rotation = rotation % 1f * 2f * (float)Math.PI;
                Projectile.position += 160f * new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
                Projectile.rotation = -rotation;
            }
            Projectile.spriteDirection = Projectile.direction;

            Projectile.frame = (int)Projectile.ai[0];
            Projectile.ai[1] += 1f;
            Projectile.ai[1] %= 300f;
            Projectile.alpha = 75 + (int)(50 * Math.Sin(Projectile.ai[1] * 2f * (float)Math.PI / 300f));

            Vector2 center263 = Projectile.Center;
            Vector2 vector163 = player.DirectionTo(player.ApplyRangeCompensation(0.0f, center263, Main.MouseWorld)) * 10f;
            if (StardustTimer > 0)
            {
                StardustTimer--;

            }
            if (StardustTimer == 0)
            {
                
                Projectile.NewProjectile(source, center263.X, center263.Y, vector163.X, vector163.Y, 1, 25, 100f, player.whoAmI);
                StardustTimer += 60;
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