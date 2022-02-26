using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace YesMod.Items.Accessories
{
	
	public class DustyBundleOfBalloons : ModItem
	{


		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The wings are a bit too alive" +
				"\nGrants multiple double jumps.");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 10000;
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.hasJumpOption_Blizzard = true;
			player.hasJumpOption_WallOfFleshGoat = true;
			player.hasJumpOption_Cloud = true;
			player.hasJumpOption_Sandstorm = true;
			player.jumpSpeedBoost += 0.30f;
		}





















}
}