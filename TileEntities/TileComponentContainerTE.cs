using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TETestMod.ComponentBases;

namespace TETestMod.TileEntities
{
    internal class TileComponentContainerTE: ModTileEntity
    {
        public List<TileComponent> components = [];

        public override bool IsTileValidForEntity(int x, int y)
        {
            var tile = Main.tile[x, y];
            return tile.HasTile;
        }

        public sealed override void Update()
        {
            if (!IsTileValidForEntity(Position.X, Position.Y))
            {
                Main.NewText("[Container]: I no longer exist!");
                Kill(Position.X, Position.Y);
            }

            if (components is null || components.Count <= 0)
                return;

            foreach (var component in components)
                component.Update();
        }

        public override void OnKill()
        {
            components.Clear();
            Main.NewText("[Container]: Components cleared upon death!");

            base.OnKill();
        }

        public override void SaveData(TagCompound tag)
        {

            base.SaveData(tag);
        }

        public override void LoadData(TagCompound tag)
        {
                

            base.LoadData(tag);
        }
    }
}