using Terraria.ModLoader;

namespace KermiumMod.Systems
{
	
	public class Keybinds : ModSystem
	{
		public static ModKeybind TarotKeybind { get; private set; }
		

		public override void Load()
		{
			
			TarotKeybind = KeybindLoader.RegisterKeybind(Mod, "TarotKeybind", "T");
			
		}

		
		public override void Unload()
		{
			TarotKeybind = null;
		}
	}
}