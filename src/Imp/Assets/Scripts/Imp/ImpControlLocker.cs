namespace Imp
{
    internal sealed class ImpControlLocker
    {
        private readonly ImpMove _impMove;
        private readonly NearInteractableChecker _nearInteractableChecker;

        public ImpControlLocker(ImpMove impMove, NearInteractableChecker nearInteractableChecker)
        {
            _impMove = impMove;
            _nearInteractableChecker = nearInteractableChecker;
        }
        public void LockControls()
        {
            _impMove.Lock();
            _nearInteractableChecker.Lock();
        }

        public void UnlockControls()
        {
            _impMove.Unlock();
            _nearInteractableChecker.Unlock();
        }
    }
}