using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speedRun = 5;

    public float MobDistanceRun;

    public Vector3 m_PlayerPosition;

    public GameObject player;

    public GameObject GameOver;
    public GameObject Ending;

    public float count;

    void Start()
    {
        GameOver.SetActive(false);
        Ending.SetActive(false);

        m_PlayerPosition = Vector3.zero;

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speedRun;

        m_PlayerPosition = player.transform.position;

        SoundManager.Instance.PlaySound2D("Monster");
    }

void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance < MobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;
            agent.SetDestination(newPos);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        count += Time.deltaTime;
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Ending.SetActive(true);
            GameOver.SetActive(false);
            SoundManager.Instance.PlaySound2D("GameClear");
            if(count >= 10)
            {
                QuitGame();
            }
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            GameOver.SetActive(true);
            Ending.SetActive(false);
            SoundManager.Instance.PlaySound2D("GameOver");
            if (count >= 10)
            {
                QuitGame();
            }
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
                  Application.Quit();//ゲームプレイ終了
#endif
    }
}
