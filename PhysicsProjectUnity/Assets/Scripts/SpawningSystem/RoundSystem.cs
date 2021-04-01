using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundSystem : MonoBehaviour
{
    [SerializeField] private Text m_roundNumber = null;
    [SerializeField] private Text m_enemiesRemaining = null;
    [SerializeField] private Text m_points = null;
    [SerializeField] private float m_doublePointsTimer = 10;
    [Tooltip("Max amount of enemies in the area.")]
    [SerializeField] public int maxSpawnInArea = 30;
    private bool isNewRound = true;
    [SerializeField]public int roundNumber = 1;
    public static RoundSystem sharedInstance;
    [HideInInspector] public int enemyPerRound;
    [HideInInspector] public int pointTotal;
    [HideInInspector] public int enemiesRemaining = 0;
    [HideInInspector] public bool doublePoints = false;
    private float m_timerDP;

    // Start is called before the first frame update
    void Start()
    {
        m_roundNumber.text = roundNumber.ToString();//Converting from int to string.
        sharedInstance = this;
        pointTotal = 0;
    }
    /// <summary>
    /// Every round, it will update so that the number of enemies are calculated,
    /// the amount of points are updated and the number of enemies remianing are updated.
    /// If there isnt any enemies left, set it to a new round.
    /// </summary>
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isNewRound == true)
        {
            enemyPerRound = roundNumber * maxSpawnInArea;
            enemiesRemaining = enemyPerRound;
            isNewRound = false;
        }
        m_roundNumber.text = "Round " + roundNumber.ToString();
        m_points.text = "Points: " + pointTotal.ToString();
        m_enemiesRemaining.text = "Enemies: " + enemiesRemaining.ToString();
        if (enemiesRemaining <= 0)
        {
            isNewRound = true;
            roundNumber += 1;
        }
        if (doublePoints)
            m_timerDP += Time.deltaTime;
        if (m_timerDP >= m_doublePointsTimer)
            doublePoints = false;
    }
}
