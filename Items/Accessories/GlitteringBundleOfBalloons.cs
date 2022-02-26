using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace YesMod.Items.Accessories
{
	
	public class GlitteringBundleOfBalloons : ModItem
	{


		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Its glimmering with warmth and confort" +
				"\nGrants multiple double jumps." +
                "\nIncreases jump speed and height");
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
			player.hasJumpOption_Unicorn = true;
			player.hasJumpOption_Cloud = true;
			player.hasJumpOption_Sandstorm = true;
			player.jumpSpeedBoost += 0.40f;
		}





















}
}