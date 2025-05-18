using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace KermiumMod.Rarities
{
	public class Dedicated : ModRarity
	{
		public override Color RarityColor => new Color(199, 44, 72);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			if (offset > 0)
			{ // If the offset is 1 or 2 (a positive modifier).
				return ModContent.RarityType<Rarities.DedicatedS>(); // Make the rarity of items that have this rarity with a positive modifier the higher tier one.
			}

			return ModContent.RarityType<Rarities.DedicatedI>(); // no 'lower' tier to go to, so return the type of this rarity.


		}
	}
}