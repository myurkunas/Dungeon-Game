using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    class Map
    {
        private int tileWidth, tileHeight, tileWidthCount, tileHeightCount;
        private ViewportAdapter viewportAdapter;
        public Map(ViewportAdapter viewportAdapter, int tileWidth, int tileHeight, int tileWidthCount, int tileHeightCount)
        {
            this.viewportAdapter = viewportAdapter;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.tileWidthCount = tileWidthCount;
            this.tileHeightCount = tileHeightCount;
        }

        public void draw(SpriteBatch _spriteBatch)
        {
            // Sets the first tile to be drawn at origin (0,0).
            Vector2 tilePosition = Vector2.Zero;

            // Begins drawing
            _spriteBatch.Begin();

            //Scans over entire x and y to draw each tile.
            for (int x = 0; x < tileWidthCount; x++)
            {
                for(int y = 0; y < tileHeightCount; y++)
                {
                    _spriteBatch.FillRectangle(tilePosition, new Size2(tileWidth, tileHeight), Color.White);
                    _spriteBatch.FillRectangle(tilePosition + new Vector2(1,1), new Size2(tileWidth - 2, tileHeight - 2), Color.Black);
                    tilePosition.Y += tileHeight;
                }
                tilePosition.Y = 0;
                tilePosition.X += tileWidth;

            }

            _spriteBatch.End();
        }

    }
}
