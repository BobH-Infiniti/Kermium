using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;


namespace KermiumMod.Rarities
{
	public class DedicatedI : ModRarity
	{
		
		public override Color RarityColor => new Color(245, 213, 161);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			if (offset > 0)
			{ 
				return ModContent.RarityType<Dedicated>(); // Make the rarity of items that have this rarity with a negative modifier the lower tier one.
			}

			return Type; 
		}
	}
}