using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩 보관
    public GameObject[] prefabs;
    //풀 담당 리스트
    List<GameObject>[] pools;
    // Start is called before the first frame update
    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for (int index = 0; index < prefabs.Length; index++) {
            pools[index] = new List<GameObject>();

        }


    }
   
        public GameObject Get(int index)
        {
            GameObject select = null;

            //.....선택한 풀의 비활성되어 있는 게임오브젝트 접근'
              // 발견하면 select변수에 할당
            //못 찾으면
              // 새롭게 생겅하고 select 함수에 할당

              //foreach는 for문인데 리스트나 배열에 사용함

            foreach(GameObject item in pools[index]) {
                if(!item.activeSelf) {
                    select = item;
                    select.SetActive(true);
                    break;
                }
            }

            if (!select) {
                select = Instantiate(prefabs[index], transform);
                pools[index].Add(select);

            }
            //Instantiate란 원본복제해서 사용하는거임 transform 쓰면 그 더러워지지 않음 칸이 그 생성칸 ㅅㅂ

            return select;
                
        }


            
        

}
