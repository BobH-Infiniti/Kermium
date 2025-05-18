using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;


namespace KermiumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class FungalLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			/* Tooltip.SetDefault("Increases damage by 6%." +
                "); */
               
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 9000;
			Item.rare = ItemRarityID.Pink;
			Item.defense = 22;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) += 0.06f;
			


		}

		

		public override void AddRecipes()
		{
			
		}
	}
}