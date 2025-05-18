using System;
using System.Collections.Generic;
using KermiumMod.Buffs;
using Terraria.GameContent.ItemDropRules;
using KermiumMod.Items;
using KermiumMod.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using static Terraria.Player;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using KermiumMod;

namespace KermiumMod.Items
{
	public class UniversalItem : GlobalItem
	{

		public override bool InstancePerEntity => true;




		
		public override void SetDefaults (Item item)
        {
			if (item.type == 2290)
            {
				item.ammo = 2290;
				item.shoot = ModContent.ProjectileType<Projectiles.Bass>();
            }
          
		
		}
		










	}










}