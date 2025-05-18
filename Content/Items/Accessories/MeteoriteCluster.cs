using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;
using static Terraria.Player;
using Terraria.GameContent.Creative;

namespace KermiumMod.Items.Accessories
{

    public class  MeteoriteCluster : ModItem
    {

        public int ClusterTimer;






        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shard of the Stars");
            /* Tooltip.SetDefault("You occasionally shoot a lunar flare." +
                "\nImmunity to fire related debuffs." +
                "\nFrom another world yet so familiar."); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        Player player = Main.player[0];



        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = 100000;
            Item.rare = ModContent.RarityType<Rarities.Imperfect>();
            Item.accessory = true;



        }



        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var source = player.GetSource_Accessory(this.Item);

            if (ClusterTimer > 0)
            {
                ClusterTimer--;

            }

            if (ClusterTimer == 0 && player.itemAnimation > 0)
            {
                Vector2 center = player.Center;
                Vector2 vector = player.DirectionTo(player.ApplyRangeCompensation(0.0f, center, Main.MouseWorld)) * 10f;
                Projectile.NewProjectile(source, center.X, center.Y, vector.X, vector.Y, 645, 100, 10f, player.whoAmI);
                ClusterTimer = 100;
            }
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.Burning] = true;
            
            player.buffImmune[BuffID.OnFire3] = true;
            player.buffImmune[BuffID.Frostburn2] = true;
        }



    }


}        

    
