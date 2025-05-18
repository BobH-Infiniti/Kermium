using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;


namespace KermiumMod.Rarities
{
	public class Banished : ModRarity
	{
		
		public override Color RarityColor => new Color(0, 128, 128);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			if (offset > 0)
			{ 
				return ModContent.RarityType<Imperfect>(); // Make the rarity of items that have this rarity with a negative modifier the lower tier one.
			}

			return Type; 
		}
	}
}