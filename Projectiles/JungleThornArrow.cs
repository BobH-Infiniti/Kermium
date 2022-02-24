using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;
using YesMod;


namespace YesMod.Projectiles
{
    public class JungleThornArrow : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Thorn Arrow");




        }


        public override void SetDefaults()
        {
            
            Projectile.width = 8;  //Set the hitbox width
            Projectile.height = 8;  //Set the hitbox height
            Projectile.aiStyle = 1; //How the projectile works
            Projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            Projectile.hostile = false; //Tells the game whether it is hostile to players or not
            Projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            Projectile.ignoreWater = false; //Tells the game whether or not projectile will be affected by water
            Projectile.DamageType = DamageClass.Ranged;   //Tells the game whether it is a ranged projectile or not
            Projectile.penetrate = 3; //Tells the game how many enemies it can hit before being destroyed
            Projectile.timeLeft = 40000; //The amount of time the projectile is alive for
            Projectile.light = 0.000000009f; //This defines the projectile light
            Projectile.arrow = true;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Projectile.spriteDirection = Projectile.direction;
        }
        public override void AI()
        {
            //red | green| blue
           
        }
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {

           

        }
        //After the projectile is dead
        public override void Kill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
          
        }


        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            
            target.AddBuff(BuffID.Poisoned, 360);
        }


    }
}