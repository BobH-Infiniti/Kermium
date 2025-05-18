using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;
using Terraria.GameContent.Creative;


namespace KermiumMod.Projectiles
{
    public class IgneousRaindrop : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Igneous Raindrop");

            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;


        }


        public override void SetDefaults()
        {
            
            Projectile.width = 32;  
            Projectile.height = 32; 
            Projectile.aiStyle = 1; 
            Projectile.friendly = true; 
            Projectile.hostile = false; 
            Projectile.tileCollide = false; 
            Projectile.ignoreWater = false; 
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1; 
            Projectile.timeLeft = 900; 
            Projectile.light = 0.09f; 
            AIType = ProjectileID.Bullet;



            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Projectile.spriteDirection = Projectile.direction;
        }
        public override void AI()
        {

            float speed = 15f; // Set the speed of the projectile
            float turnSpeed = 0.1f; // Set the turning speed of the projectile
            float maxDistance = 300f; // Set the maximum distance it can travel before stopping

            // Find the closest enemy
            float closestDist = maxDistance;
            NPC target = null;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.CanBeChasedBy() && !npc.friendly)
                {
                    float dist = Vector2.Distance(Projectile.Center, npc.Center);
                    if (dist < closestDist)
                    {
                        closestDist = dist;
                        target = npc;
                    }
                }
            }

            // Turn towards the target
            if (target != null)
            {
                Vector2 direction = target.Center - Projectile.Center;
                direction.Normalize();
                Projectile.velocity = (Projectile.velocity * (1 - turnSpeed)) + (direction * speed * turnSpeed);
            }

            // Set the rotation of the projectile to the velocity direction
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;


        }

        

        
        public override void OnKill(int timeLeft)
        {
            
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.DD2_WitherBeastCrystalImpact, Projectile.position);
            Vector2 target2 = Projectile.Center;
            Main.rand.NextFloat();
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 vector2 = Projectile.oldPos[k];
                if (vector2 == Vector2.Zero)
                {
                    break;
                }
                int num13 = Main.rand.Next(1, 3);
                float num14 = MathHelper.Lerp(0.3f, 1f, Utils.GetLerpValue(Projectile.oldPos.Length, 0f, k, clamped: true));
                if ((float)k >= (float)Projectile.oldPos.Length * 0.3f)
                {
                    num13--;
                }
                if ((float)k >= (float)Projectile.oldPos.Length * 0.75f)
                {
                    num13 -= 2;
                }
                vector2.DirectionTo(target2).SafeNormalize(Vector2.Zero);
                target2 = vector2;
                for (float num15 = 0f; num15 < (float)num13; num15++)
                {
                    int num16 = Dust.NewDust(vector2, Projectile.width, Projectile.height, 267, 0f, 0f, 0, Color.Orange);
                    Dust dust = Main.dust[num16];
                    dust.velocity *= Main.rand.NextFloat() * 0.8f;
                    Main.dust[num16].noGravity = true;
                    Main.dust[num16].scale = 0.9f + Main.rand.NextFloat() * 1.2f;
                    Main.dust[num16].fadeIn = Main.rand.NextFloat() * 1.2f * num14;
                    dust = Main.dust[num16];
                    dust.scale *= num14;
                    if (num16 != 6000)
                    {
                        Dust dust6 = Dust.CloneDust(num16);
                        dust = dust6;
                        dust.scale /= 2f;
                        dust = dust6;
                        dust.fadeIn *= 0.85f;
                        dust6.color = new Color(255, 255, 255, 255);
                    }
                }
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            // Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 119, 0, 200) * ((255f - (float)Projectile.alpha) / 255f);
        }

        


    }
}