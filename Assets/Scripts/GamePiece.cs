using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GamePiece : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    [SerializeField] private Node currentNode;
    public Node CurrentNode => currentNode;
    public Node PreviousNode { get; private set; }
    public bool IsMoving { get; private set; }

    public void TryMove(Vector3 inputVec) {
        float shortestDis = 0.5f;
        Node closestNode = null;
        foreach (Node node in currentNode.NodeConnections) {
            float dis = Vector3.Distance((node.transform.position - currentNode.transform.position).normalized, inputVec);
            //Debug.Log($"Distance to {node.name}: {dis}");
            if (dis < shortestDis) {
                shortestDis = dis;
                closestNode = node;
            }
        }
        if (closestNode != null) {
            UpdateNode(closestNode);
        }
    }
    
    void UpdateNode(Node newNode) {
        PreviousNode = currentNode;
        currentNode = newNode;
        StartCoroutine(Move(currentNode.transform.position));
    }

    IEnumerator Move(Vector3 dest) {
        if (IsMoving) {
            yield break;
        }

        IsMoving = true;

        while (MoveToNode(dest)) { yield return null; }

        IsMoving = false;
    }

    bool MoveToNode(Vector3 dest) {
        return dest != (transform.position = Vector3.MoveTowards(transform.position, dest, moveSpeed * Time.deltaTime));
    }
}
