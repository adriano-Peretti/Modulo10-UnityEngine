using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private List<PatrolData> listPatrols = new List<PatrolData>();
    [SerializeField] private Move _move;
    [SerializeField] private int patrol;
    [SerializeField] private TMP_Text texto;


    void Start()
    {
        patrol = 0;
        texto.text = $"Patrulha: {patrol}";
        listPatrols.Add(new PatrolData() { CheckPoint = 1, MoveSpeed = 6, Boost = 4f, MoveDirection = Vector3.back });
        listPatrols.Add(new PatrolData() { CheckPoint = 2, MoveSpeed = 6, Boost = 3.5f, MoveDirection = Vector3.left });
        listPatrols.Add(new PatrolData() { CheckPoint = 3, MoveSpeed = 6, Boost = 5f, MoveDirection = Vector3.forward });
        listPatrols.Add(new PatrolData() { CheckPoint = 4, MoveSpeed = 6, Boost = 3f, MoveDirection = Vector3.right });
        listPatrols.Add(new PatrolData() { CheckPoint = 5, MoveSpeed = 6, Boost = 4f, MoveDirection = Vector3.back });
        listPatrols.Add(new PatrolData() { CheckPoint = 6, MoveSpeed = 0, Boost = 0, MoveDirection = Vector3.zero });
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PatrolDirection(patrol);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("CheckPoint"))
        {
            if (patrol < 5)
            {
                patrol++;
            }
            else
            {
                patrol = 0;
            }
            texto.text = $"Patrulha: {patrol} \n" +
                $"Speed: {_move.Speed} \n" +
                $"Boost: {_move.Boost} \n" +
                $"Diretion: {_move.Direction}";
        }
    }


    private void PatrolDirection(int patrol)
    {
        _move.Speed = listPatrols[patrol].MoveSpeed;
        _move.Boost = listPatrols[patrol].Boost;
        _move.Direction = listPatrols[patrol].MoveDirection;
    }
}
