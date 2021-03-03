using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundSystem : MonoBehaviour
{
    [SerializeField] private Text m_roundNumber = null;
    [SerializeField] private Text m_enemiesRemaining = null;
    [SerializeField] private Text m_points = null;
    [Tooltip("Max amount of enemies in the area.")]
    [SerializeField] public int maxSpawnInArea = 30;
    private bool isNewRound = true;
    [SerializeField]public int roundNumber = 1;
    public static RoundSystem sharedInstance;
    [HideInInspector] public int enemyPerRound;
    [HideInInspector] public int pointTotal;
    [HideInInspector] public int enemiesRemaining = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_roundNumber.text = roundNumber.ToString();
        sharedInstance = this;
        pointTotal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNewRound == true)
        {
            enemyPerRound = roundNumber * maxSpawnInArea;
            enemiesRemaining = enemyPerRound;
            isNewRound = false;
        }
        m_roundNumber.text = roundNumber.ToString();
        m_points.text = "Points: " + pointTotal.ToString();
        m_enemiesRemaining.text = "Enemies: " + enemiesRemaining.ToString();
        if (enemiesRemaining <= 0)
        {
            isNewRound = true;
            roundNumber += 1;
        }

    }
}
