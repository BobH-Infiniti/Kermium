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
    public class MGSlash : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Holy Moonlight Greatslash");

            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;


        }


        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 3;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            AIType = ProjectileID.Bullet;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); 
           
            



        }
        public override void AI()
        {

            Projectile.alpha -= 40;
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
            Projectile.spriteDirection = Projectile.direction;
            Projectile.localAI[0] += 1f;
            for (int num66 = 0; num66 < 1; num66++)
            {
                Vector2 spinningpoint4 = Utils.RandomVector2(Main.rand, -0.5f, 0.5f) * new Vector2(20f, 80f);
                spinningpoint4 = spinningpoint4.RotatedBy(Projectile.velocity.ToRotation());
                Dust dust2 = Dust.NewDustDirect(Projectile.Center, 0, 0, 160);
                dust2.alpha = 127;
                dust2.fadeIn = 1.5f;
                dust2.scale = 1.3f;
                dust2.velocity *= 0.3f;
                dust2.position = Projectile.Center + spinningpoint4;
                dust2.noGravity = true;
                dust2.noLight = true;
                dust2.color = new Color(0, 128, 128, 0);
            }
            Lighting.AddLight(Projectile.Center, 0f, 1.28f, 1.28f);

        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(0, 128, 128, 200) * ((255f - (float)Projectile.alpha) / 255f);
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
        public override void OnKill(int timeLeft)
        {
           


        }



    }
}