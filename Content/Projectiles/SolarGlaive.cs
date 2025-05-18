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
    public class SolarGlaive : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Solar Glaive");




        }


        public override void SetDefaults()
        {

            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.aiStyle = 3;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            AIType = ProjectileID.PaladinsHammerFriendly;
            Projectile.tileCollide = false;



        }
        
       
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {


            float num859 = Main.rand.NextFloat() * ((float)Math.PI * 2f);
            var source = Projectile.GetSource_FromThis();

            float num860 = 2f;

                float f2 = num859 + num860 * ((float)Math.PI * 2f);
                Vector2 velocity = f2.ToRotationVector2() * (4f + Main.rand.NextFloat() * 2f);
                velocity += Vector2.UnitY * -1f;
                int num861 = Projectile.NewProjectile(source, Projectile.Center, velocity, 612, damageDone * 2, 0f, Projectile.owner); //ProjectileID.612 is Solar Explosion
                Projectile projectile = Main.projectile[num861];
                Projectile projectile2 = projectile;
                projectile2.timeLeft -= Main.rand.Next(50);

            if (hit.Crit)
            {
                projectile.damage = projectile.damage * 3;
                Projectile.NewProjectile(source, Projectile.Center, velocity, 296, damageDone * 5, 0f, Projectile.owner); //ProjectileID.953 is Solar Explosion
                
                
            }
            


        }
        //After the projectile is dead
        public override void OnKill(int timeLeft)
        {
           


        }


    }
}