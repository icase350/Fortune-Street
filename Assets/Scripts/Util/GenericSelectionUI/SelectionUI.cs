using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDE.GenericSelectionUI {
    public enum SelectionType { List, Grid }
    public enum SelectionWrap { Wrap, Clamp }

    public class SelectionUI<T> : MonoBehaviour where T : ISelectableItem {
        List<T> items;
        protected int selectedItem = 0;

        SelectionType selectionType;
        int gridWidth = 2;
        SelectionWrap selectionWrap;

        float selectionTimer = 0;
        const float selectionSpeed = 5f;

        public event Action<int> OnSelected;
        public event Action OnBack;

        public void SetSelectionSettings(SelectionType selectionType, int gridWidth, SelectionWrap wrapSetting) {
            this.selectionType = selectionType;
            this.gridWidth = gridWidth;
            this.selectionWrap = wrapSetting;
        }

        public void SetItems(List<T> items) {
            this.items = items;
            items.ForEach(i => i.Init());
            UpdateSelectionInUI();
        }

        public virtual void HandleUpdate() {
            UpdateSelectionTimer();
            int prevSelection = selectedItem;
            if (selectionType == SelectionType.List)
                HandleListSelection();
            else if (selectionType == SelectionType.Grid)
                HandleGridSelection();

            if (selectionWrap == SelectionWrap.Wrap)
                selectedItem = (selectedItem % items.Count + items.Count) % items.Count;
            else
                selectedItem = Mathf.Clamp(selectedItem, 0, items.Count - 1);

            if (selectedItem != prevSelection)
                UpdateSelectionInUI();

            if (Input.GetButtonDown("Action"))
                OnSelected?.Invoke(selectedItem);
            else if (Input.GetButtonDown("Back"))
                OnBack?.Invoke();
        }

        void HandleListSelection() {
            float v = Input.GetAxis("Vertical");

            if (selectionTimer == 0 && Mathf.Abs(v) > 0.2f) {
                selectedItem += -(int)Mathf.Sign(v);
                SetSelectionTimer();
            }
        }

        void HandleGridSelection() {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");

            if (selectionTimer == 0 && (Mathf.Abs(v) > 0.2f || Mathf.Abs(h) > 0.2f)) {
                if (Mathf.Abs(h) > Mathf.Abs(v))
                    selectedItem += (int)Mathf.Sign(h);
                else
                    selectedItem += -(int)Mathf.Sign(v) * gridWidth;

                SetSelectionTimer();
            }
        }

        public virtual void UpdateSelectionInUI() {
            for (int i = 0; i < items.Count; i++) {
                items[i].OnSelectionChanged(i == selectedItem);
            }
        }

        void SetSelectionTimer() {
            selectionTimer = 1 / selectionSpeed;
        }

        void UpdateSelectionTimer() {
            if (selectionTimer > 0)
                selectionTimer = Mathf.Clamp(selectionTimer - Time.deltaTime, 0, selectionTimer);
        }
    }
}
