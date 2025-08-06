using Terraria;
using TETestMod.ComponentBases;

namespace TETestMod.Components
{
    internal class TestTileComponent: TileComponent
    {
        private int _timer;

        public int timerToSet;

        public override void Init()
        {
            Main.NewText($"[{GetType().Name}] @ ({Position.X}, {Position.Y}): I have been placed successfully!");

            base.Init();
        }

        public override void Update()
        {
            _timer--;

            if (_timer % 60 == 0)
                Main.NewText($"[{GetType().Name}] @ ({Position.X}, {Position.Y}): 1 second has passed!");

            if (_timer <= 0)
            {
                Main.NewText($"[{GetType().Name}] @ ({Position.X}, {Position.Y}): I am still active!");
                _timer = timerToSet;
            }

            base.Update();
        }
    }
}