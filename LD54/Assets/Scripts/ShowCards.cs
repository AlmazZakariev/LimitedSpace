using Packages.Rider.Editor.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;

public class ShowCards : MonoBehaviour
{
    public GameObject CardPrefab;

    Dictionary<Card, GameObject> Cards = new Dictionary<Card, GameObject>();
    List<Card> CurrentCards = new List<Card>();
    bool FirstStart = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!FirstStart)
        {
            FirstStart = true;
            InitializeCards();
        }

    }

    private void InitializeCards()
    {
        Cards.Add(new Card(new List<Stats> { Stats.food }, new List<Stats> { Stats.count }, "Карточка один"), null);
        Cards.Add(new Card(new List<Stats> { Stats.count }, new List<Stats> { Stats.electricity }, "Карточка два"), null);
    }

    private List<GameObject> _cards = new List<GameObject>();
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTwoCars()
    {
        Vector2 spawnPos = new Vector2(20, -5);
        SpawnCard(spawnPos);
        spawnPos = new Vector2(70, -5);
        SpawnCard(spawnPos);

    }
    public void SpawnCard(Vector2 pos)
    {
        var keys = Cards.Keys.ToList();
        var a = keys[UnityEngine.Random.Range(0, Cards.Keys.Count)];

        
       
        // instantiate ball at random spawn location
        Cards[a] = Instantiate(CardPrefab, pos, CardPrefab.transform.rotation);
        CurrentCards.Add(a);

        Debug.Log(a.Text);
    }
}
public enum Stats
{
    count,
    electricity,
    oxygen,
    food, 
    happiness

}
public class Card
{
    public List<Stats> PosStats = new List<Stats>();
    public List<Stats> NegStats = new List<Stats>();
    public string Text;
    public Card(List<Stats> posStats, List<Stats> negStats, string text)
    {
        PosStats = posStats;
        NegStats = negStats;
        Text = text;
    }
}
