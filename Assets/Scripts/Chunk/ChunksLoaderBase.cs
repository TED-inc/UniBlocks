using UnityEngine;

namespace TEDinc.UniBlocks
{
    public abstract class ChunksLoaderBase : MonoBehaviour
    {
        protected WorldChunksDrawer worldDrawer;


        public virtual void Setup(WorldChunksDrawer worldDrawer)
        {
            this.worldDrawer = worldDrawer;
        }
    }
}