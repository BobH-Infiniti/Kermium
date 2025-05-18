using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace KermiumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class FrigidHood : ModItem
	{
		public override void SetStaticDefaults() {
			/* Tooltip.SetDefault("Increases magic damage by 7%." +
                "\nIncreases mana by 30."); */
               
		}



		public int IcyCD;

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 1;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) += 0.07f;
			player.statManaMax2 += 30;



		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<Items.Armor.FrigidChainmail>() && legs.type == ItemType<Items.Armor.FrigidGreaves>();
		}


		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Magic damage is increased by 2%" +
                "\nDouble tapping DOWN allows you to use magic weapons without using mana for a short time.";
			player.GetDamage(DamageClass.Magic) += 0.02f;

			if (IcyCD > 0)
			{
				IcyCD--;
			}
			if (player.whoAmI != Main.myPlayer)
				return;


			if (player.controlDown && player.releaseDown && player.doubleTapCardinalTimer[0] > 0 && player.doubleTapCardinalTimer[0] != 15 && IcyCD == 0)
			{
				
				
					IcyCD = 4200;
				    
				    SoundEngine.PlaySound(SoundID.DD2_BetsyScream, player.position);
					player.AddBuff(ModContent.BuffType<Buffs.FrigidCD>(), 4200);
				    player.AddBuff(ModContent.BuffType<Buffs.FrigidManaBuff>(), 360);





			}



		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}