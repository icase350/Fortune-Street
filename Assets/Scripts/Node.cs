using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    [SerializeField] List<Node> nodeConnections = new List<Node>();

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;

        foreach (Node node in nodeConnections) {
            Gizmos.DrawLine(this.transform.position, node.transform.position);
        }
    }
}
