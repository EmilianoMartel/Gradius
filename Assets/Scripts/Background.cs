using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] GameObject backgroundImage;
    [SerializeField] List<GameObject> backgroundList;
    [SerializeField] float p_direction = -1f;
    [SerializeField] float p_speed = 1f;
    private Vector3 p_instantiatePosition = new Vector3(0,0,10);

    //constantes de posicion final y diferencia entre fondos
    private const float FINAL_POSITION = -9.96f;
    private const float DIFF_X = 9.5f;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            backgroundList.Add(Instantiate(backgroundImage, p_instantiatePosition,Quaternion.identity));
            p_instantiatePosition.x += DIFF_X;
        }
        p_instantiatePosition.x -= DIFF_X;
        MoveLogic();
    }

    private void Update()
    {
        MoveLogic();
    }

    private void MoveLogic()
    {
        for (int i = 0; i < backgroundList.Count; i++)
        {
            backgroundList[i].transform.Translate(p_speed * p_direction * Time.deltaTime,0,0, Space.World);
            if (backgroundList[i].transform.position.x <= FINAL_POSITION)
            {
                Destroy(backgroundList[i]);
                backgroundList.RemoveAt(i);
                backgroundList.Add(Instantiate(backgroundImage,transform.position,Quaternion.identity));
            }
        }   
    }
}
