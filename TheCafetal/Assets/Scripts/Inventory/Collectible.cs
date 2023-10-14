using System;
using UnityEngine;

namespace jdmozo.Inventory
{
    public abstract class Collectible : MonoBehaviour, ICollectible
    {
        public abstract void Collect();
    }
}
