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
    public class LucreciaBomb : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Blood of the Oceans");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;



        }


        public override void SetDefaults()
        {
            
            Projectile.width = 32;  //Set the hitbox width
            Projectile.height = 32;  //Set the hitbox height
            Projectile.aiStyle = 171; //How the projectile works
            Projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            Projectile.hostile = false; //Tells the game whether it is hostile to players or not
            Projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            Projectile.ignoreWater = false; //Tells the game whether or not projectile will be affected by water
            Projectile.DamageType = DamageClass.Melee;   //Tells the game whether it is a ranged projectile or not
            Projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
            Projectile.timeLeft = 120; //The amount of time the projectile is alive for
            Projectile.light = 0.09f; //This defines the projectile light
            Projectile.arrow = true;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Projectile.spriteDirection = Projectile.direction;
        }
        public override void AI()
        {
            for (int i = 0; i < 10; i++)
            {
                int num249 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 103, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 1.2f);
                Main.dust[num249].noGravity = true;
             
                Dust dust2 = Main.dust[num249];
                dust2.velocity *= 0.3f;

            }

        }
       
       
        public override void OnKill(int timeLeft)
        {
            var source = Projectile.GetSource_FromThis();

            for (int num410 = 0; num410 < 6; num410++)
                {
                    float num411 = (0f - Projectile.velocity.X) * (float)Main.rand.Next(20, 50) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
                    float num412 = (0f - Math.Abs(Projectile.velocity.Y)) * (float)Main.rand.Next(30, 50) * 0.01f + (float)Main.rand.Next(-20, 5) * 0.4f;
                    Projectile.NewProjectile(source, Projectile.Center.X + num411, Projectile.Center.Y + num412, num411, num412, ModContent.ProjectileType<Projectiles.LucreciaSplash>(), (int)((double)Projectile.damage * 2), 0f, Projectile.owner);
                }
            
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.DD2_WitherBeastCrystalImpact, Projectile.position);
        }


        


    }
}