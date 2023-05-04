using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GamePiece : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    [SerializeField] private Node currentNode;
    private Stack<Node> history = new Stack<Node>();

    public Node CurrentNode => currentNode;
    public Node PreviousNode { get; private set; }
    public bool IsMoving { get; private set; }
    public int Steps { get; set; }
    public Stack<Node> History => history;

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
            StartCoroutine(TryMove(closestNode));
        }
    }

    public IEnumerator TryMove(Node newNode) {
        bool movedForward = false;
        if (newNode == PreviousNode && history.Count == 0) {
            yield break;
        } else if (history.Count > 0 && newNode == history.Peek()) {
            history.Pop();
            Steps++;
        } else {
            history.Push(currentNode);
            Steps--;
            movedForward = true;
        }

        if (!movedForward)
            currentNode.GetComponent<IBoardSpace>()?.UndoPass(Player.I);
        yield return UpdateNode(newNode);
        if (movedForward)
            currentNode.GetComponent<IBoardSpace>()?.Pass(Player.I);

        if (Steps == 0) {
            Player.I.Die.gameObject.SetActive(false);
            yield return GameController.I.StateMachine.PushAndWait(SpaceConfirmState.I);
        } else if (Steps > 0) {
            Player.I.Die.gameObject.SetActive(true);
            GetComponent<Player>().Die.ChangeValue(Steps);
        }
    }

    IEnumerator UpdateNode(Node newNode) {
        currentNode = newNode;
        yield return Move(currentNode.transform.position);
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

    internal void EndTurn() {
        PreviousNode = history.Peek();
        history.Clear();
    }
}
