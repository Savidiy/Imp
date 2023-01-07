using System.Collections.Generic;

namespace Imp
{
    internal interface IInteractablesHolder
    {
        IReadOnlyList<Interactable> Interactables { get; }
        void Remove(Interactable interactable);
    }
}