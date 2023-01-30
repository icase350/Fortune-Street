using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoardSpace {
    public abstract void Pass(Player player);
    public abstract void UndoPass(Player player);
    public abstract void Land(Player player);
    public abstract void Refresh();
}
