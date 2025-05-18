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
    public class AlteraSolem : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Altera Solem");




        }


        public override void SetDefaults()
        {

            Projectile.width = 44;
            Projectile.height = 32;
            Projectile.aiStyle = 3;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.light = 0.5f;
            Projectile.friendly = true;
            AIType = 301;
            Projectile.tileCollide = true;



        }
        public override void AI()
        {
            
           
        }
       
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) //When you hit an NPC
        {
            var source = Projectile.GetSource_FromThis();

            for (int num15 = 0; num15 < 3; num15++)
			{
				float x = Projectile.position.X + (float)Main.rand.Next(-400, 400);
				float y = Projectile.position.Y - (float)Main.rand.Next(500, 800);
				Vector2 vector = new Vector2(x, y);
				float num16 = Projectile.position.X + (float)(Projectile.width / 2) - vector.X;
				float num17 = Projectile.position.Y + (float)(Projectile.height / 2) - vector.Y;
				num16 += (float)Main.rand.Next(-100, 101);
				float num18 = (float)Math.Sqrt(num16 * num16 + num17 * num17);
				num18 = 23f / num18;
				num16 *= num18;
				num17 *= num18;
				int type = 118;
				
				int num20 = Terraria.Projectile.NewProjectile(source, x, y, num16, num17, type, damageDone, 0f, Projectile.owner);
				Main.projectile[num20].ai[1] = Projectile.position.Y;
			}


		}
        //After the projectile is dead
        public override void OnKill(int timeLeft)
        {
           


        }


    }
}