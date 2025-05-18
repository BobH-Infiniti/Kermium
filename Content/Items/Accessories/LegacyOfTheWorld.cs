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

    public class  LegacyOfTheWorld : ModItem
    {



        public int ClusterTimer;
        public int FlushroomTimer;




        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Legacy of the World");
            /* Tooltip.SetDefault("Increases attack speed by 8%" +
                "\nIncreases melee speed by 7%" +
                "\nIncreases damage by 8%" +
                "\nIncreases melee, ranged and minion damage by 7%" +
                "\nIncreases magic damage by 4%" +
                "\nIncreases crit chance by 4%" +
                "\nIncreases armor penetration by 6" +
                "\nIncreases movement speed by 5%" +
                "\nIncreases damage reduction by 5%" +
                "\nIncreases defense by 5" +
                "\nIncreases life regeneration" +
                "\nIncreases max HP by 70" +
                "\nEffects of all biome accessories" +
                "\nIf the visuals of this item are toggled on, your damage is significantly increased, but you take more damage and become briefly stoned on a received hit"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        Player player = Main.player[0];



        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = 10000000;
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
                Projectile.NewProjectile(source, center.X, center.Y, vector.X, vector.Y, 645, 355, 10f, player.whoAmI);
                ClusterTimer = 100;
            }
            if (FlushroomTimer > 0)
            {
                FlushroomTimer--;

            }

            if (FlushroomTimer == 0 && player.itemAnimation > 0)
            {
                Vector2 center = player.Center;
                Vector2 vector = player.DirectionTo(player.ApplyRangeCompensation(0.0f, center, Main.MouseWorld)) * 10f;
                Projectile.NewProjectile(source, center.X, center.Y, vector.X, vector.Y, ModContent.ProjectileType<Projectiles.MushroomBolt>(), 200, 100f, player.whoAmI);
                FlushroomTimer = 70;
            }
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[BuffID.OnFire3] = true;
            player.buffImmune[BuffID.Frostburn2] = true;

            player.endurance += 0.05f;
            player.statDefense += 5;
            player.moveSpeed += 0.05f;
            player.GetDamage(DamageClass.Generic) += 0.08f;
            player.GetDamage(DamageClass.Ranged) += 0.07f;
            player.GetDamage(DamageClass.Melee) += 0.07f;
            player.GetDamage(DamageClass.Summon) += 0.07f;
            player.GetDamage(DamageClass.Magic) += 0.04f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.07f;
            player.GetAttackSpeed(DamageClass.Generic) += 0.08f;
            player.statLifeMax2 += 70;

            player.GetModPlayer<AccessoryPlayer>().WorldCluster = true;
            player.GetModPlayer<AccessoryPlayer>().LizardFetish = true;
            player.GetModPlayer<AccessoryPlayer>().HolyVirtue = true;
            player.GetModPlayer<AccessoryPlayer>().Granoot = true;
            player.GetModPlayer<AccessoryPlayer>().TribalPendant = true;
            player.GetModPlayer<AccessoryPlayer>().JawsumAcc = true;
            player.GetModPlayer<AccessoryPlayer>().EngorgedDoll = true;

            if (hideVisual)
            {
                player.GetModPlayer<AccessoryPlayer>().BrokenNazar = true;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.DivineAcorn>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.DriedArcanum>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.PermafrostPendant>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.TribalPendant>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.AquaticJawbreaker>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.InfectedFlesh>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.GoryTendril>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.MarvelousMarble>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.Granoot>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.Flushroom>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.MeteoriteCluster>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.EngorgedDoll>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.BrokenNazar>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.HolyVirtue>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.KermiumBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.SearingShard>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.RuinFragment>(), 10);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.DecayedHeroRune>(), 1);
            
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }

    }


}        

    
