using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TETestMod.Components;
using TETestMod.Helpers;
using TETestMod.TileEntities;

namespace TETestMod.Tiles
{
    internal class TestTile: ModTile
    {
        public override string Texture => "TETestMod/icon";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = [16, 18];
            TileObjectData.newTile.StyleHorizontal = true;

            // This is the important line!
            TileObjectData.newTile.HookPostPlaceMyPlayer = ModContent.GetInstance<TileComponentContainerTE>().Generic_HookPostPlaceMyPlayer;

            TileObjectData.addTile(Type);

            base.SetStaticDefaults();
        }

        public override void PlaceInWorld(int i, int j, Item item)
        {
            TileHelpers.TryAddComponent(i, j, new TestTileComponent(), x => x.timerToSet = 360);

            base.PlaceInWorld(i, j, item);
        }
    }

    public class TestTileItem: ModItem
    {
        public override string Texture => "TETestMod/icon";

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<TestTile>());
        }
    }
}
