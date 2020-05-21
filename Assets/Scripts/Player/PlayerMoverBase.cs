namespace TEDinc.UniBlocks
{
    public abstract class PlayerMoverBase
    {
        protected readonly PlayerBodyController playerBodyController;
        public abstract void ExecuteOnFixedUpdate();

        protected PlayerMoverBase(PlayerBodyController playerBodyController)
        {
            this.playerBodyController = playerBodyController;
        }
         
    }
}