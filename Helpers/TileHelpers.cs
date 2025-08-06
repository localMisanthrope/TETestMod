using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using TETestMod.ComponentBases;
using TETestMod.TileEntities;

namespace TETestMod.Helpers
{
    internal class TileHelpers
    {
        public static bool TryAddComponent<T>(int i, int j, T component, Action<T> init = null) where T : TileComponent
        {
            if (!TileEntity.TryGet(i, j, out TileComponentContainerTE entity))
                return false;

            if (HasComponent<T>(i, j))
                return false;

            component.Position = entity.Position.ToPoint(); //Perhaps handle within Init()?
            component.Init();
            init?.Invoke(component);
            entity.components.Add(component);
            return true;
        }

        public static bool TryGetComponent<T>(int i, int j, out T result) where T : TileComponent
        {
            if (!TileEntity.TryGet(i, j, out TileComponentContainerTE entity))
            {
                result = null;
                return false;
            }

            var component = entity.components.First(x => x.GetType() == typeof(T));

            if (component is null)
            {
                result = null;
                return false;
            }

            result = (T)component;
            return true;
        }

        public static bool HasComponent<T>(int i, int j) where T : TileComponent 
            => TileEntity.TryGet(i, j, out TileComponentContainerTE entity) && entity.components.FirstOrDefault(x => x.GetType() == typeof(T)) is not null;

        public static bool RemoveComponent<T>(int i, int j) where T : TileComponent
        {
            if (!TileEntity.TryGet(i, j, out TileComponentContainerTE entity))
                return false;

            if (!TryGetComponent(i, j, out T result))
                return false;

            entity.components.Remove(result);
            return true;
        }
    }
}