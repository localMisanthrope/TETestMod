using Terraria;
using Terraria.ModLoader.IO;
using TETestMod.ComponentBases;

namespace TETestMod.Components
{
    internal class TestTileComponent: TileComponent
    {
        private int _timer;

        public int timerToSet;

        public int extraData;

        public override void Init()
        {
            Main.NewText($"[{GetType().Name}] @ ({Position.X}, {Position.Y}): I have been placed successfully!");

            extraData = Main.rand.Next(0, 10);

            base.Init();
        }

        public override void Update()
        {
            _timer--;

            if (_timer % 60 == 0)
                Main.NewText($"[{GetType().Name}] @ ({Position.X}, {Position.Y}): 1 second has passed!");

            if (_timer <= 0)
            {
                Main.NewText($"[{GetType().Name}] @ ({Position.X}, {Position.Y}): Extra Save Data is ({extraData})!");
                Main.NewText($"[{GetType().Name}] @ ({Position.X}, {Position.Y}): I am still active!");
                _timer = timerToSet;
            }

            base.Update();
        }

        public override void SaveData(TagCompound tag)
        {
            tag[nameof(extraData)] = extraData;
            tag[nameof(timerToSet)] = timerToSet;

            base.SaveData(tag);
        }

        public override void LoadData(TagCompound tag)
        {
            extraData = tag.GetInt(nameof(extraData));
            timerToSet = tag.GetInt(nameof(timerToSet));

            base.LoadData(tag);
        }
    }
}