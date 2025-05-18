using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;


namespace KermiumMod.Projectiles
{
    public class KermiumSword : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Kermium Blade");




        }


        public override void SetDefaults()
        {

            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 27;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 2;
            Projectile.light = 0.5f;
            Projectile.alpha = 200;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
        }
      
        
        public override void OnKill(int timeLeft)
        {
            
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {

            target.AddBuff(ModContent.BuffType<Buffs.KermiumAffliction>(), 300);
        }


    }
}