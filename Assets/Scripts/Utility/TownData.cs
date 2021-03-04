using System;
using System.Collections.Generic;
[Serializable]
public class TownData
{
    public float money;
    public float attraction;
    public int incomes;
    public float expenses;
    public int workload;
    public int quarters;
    public string time;
    public List<Building> buildings = new List<Building>();
}
