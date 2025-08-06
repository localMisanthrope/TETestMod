using Microsoft.Xna.Framework;
using Terraria;

namespace TETestMod.ComponentBases
{
    public abstract class TileComponent
    {
        public Tile Owner => Main.tile[Position];

        public Point Position;

        public virtual void Init() { }

        public virtual void Update() { }
    }
}