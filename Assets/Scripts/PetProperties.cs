using System;

[System.Serializable]
public class PetProperties
{
    public string TargetName;
    public string name;

    private readonly int maxExperience = 100;
    public int Level { get; set; }
    public int Experience { get; set; }
    public int Life { get; set; } = 100;
    public int Hungry { get; set; } = 100;
    public int Happiness { get; set; } = 100;
    public int Cleanness { get; set; } = 100;
}