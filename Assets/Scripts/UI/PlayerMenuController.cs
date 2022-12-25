using GDE.GenericSelectionUI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMenuController : SelectionUI<MenuButton> {
    private void Start() {
        SetSelectionSettings(SelectionType.List, 1, SelectionWrap.Wrap);
        SetItems(GetComponentsInChildren<MenuButton>().ToList());
    }
}
