using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ModLoader;

namespace LansSimpleMouseHighlight
{
	public class SimpleMouseHighlight : Mod
	{
		public SimpleMouseHighlight()
		{
		}

		public override void Load()
		{
			IL.Terraria.Main.DrawCursor += AddExtraDraw;
		}

		public void AddExtraDraw(ILContext il)
		{
			var c = new ILCursor(il);
			var textureReq = ModContent.Request<Texture2D>("LansSimpleMouseHighlight/cursor");
			c.EmitDelegate<Action>(delegate () {
				if (!textureReq.Value.IsDisposed)
				{
					var texture = textureReq.Value;
					Microsoft.Xna.Framework.Color color = Main.cursorColor;
					Main.spriteBatch.Draw(texture, new Vector2((float)Main.mouseX - texture.Width / 2, (float)Main.mouseY - texture.Height / 2) + Vector2.One, null, color, 0f, default(Vector2), 1, SpriteEffects.None, 0f);

				}
			});

		}
	}
}