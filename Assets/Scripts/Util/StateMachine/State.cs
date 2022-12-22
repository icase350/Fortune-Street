using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDEUtils.StateMachine {
    public class State<T> : MonoBehaviour {
        public virtual void Enter(T owner) { }

        public virtual void Execute() { }

        public virtual void Exit() { }

        public virtual void SoftEnter() { }

        public virtual void SoftExit() { }
    }
}
