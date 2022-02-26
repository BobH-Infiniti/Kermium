using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using YesMod;
using static Terraria.Player;


namespace YesMod.Projectiles
{
    public class BelowZero : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Below Zerowo");




        }
        

        public override void SetDefaults()
        {

            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.aiStyle = 19;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.light = 0.5f;
            Projectile.scale = 1.27f;
            Projectile.hide = true;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            AIType = 66;
            Projectile.ownerHitCheck = true;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            var source = Projectile.GetProjectileSource_FromThis();
            if (Projectile.localAI[0] == 0f && Main.myPlayer == Projectile.owner)
            {
                Projectile.localAI[0] = 1f;
                if (Collision.CanHit(player.position, player.width, player.height, Projectile.position, Projectile.width, Projectile.height))
                {
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X * 2.4f, Projectile.velocity.Y * 2.4f, 337, (int)((double)Projectile.damage * 0.8), Projectile.knockBack * 0.85f, Projectile.owner);
                }
            }
            
        }
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
            target.AddBuff(BuffID.Frostburn, 360);


        }
        //After the projectile is dead
       


        


    }
}