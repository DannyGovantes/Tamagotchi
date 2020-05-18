using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetCreator : MonoBehaviour
{


    private static List<PetProperties> pets = new List<PetProperties>()
    {
        new PetProperties(){TargetName="Tilo2", name="Tilo2"},
        new PetProperties(){TargetName="Shuny", name="Shuny"},
        new PetProperties(){TargetName="Riko", name="Riko"},
        new PetProperties(){TargetName="Nomi", name="Nomi"},
        
    };
    private static PetProperties ClonePet(PetProperties pet)
    {
        PetProperties temPet = new PetProperties()
        {
            TargetName = pet.TargetName,
            name = pet.name,
            Level = pet.Level,
            Experience = pet.Experience,
            Life = pet.Life,
            Hungry = pet.Hungry,
            Happiness = pet.Happiness,
            Cleanness = pet.Cleanness,

        };
        return temPet;

    }
    public static PetProperties GetPetByTargetName(string targetName)
    {
        PetProperties loadPet = new PetProperties();
        if (PlayerPrefs.HasKey(targetName) == true)
        {
            loadPet = LoadPetInfo(targetName);
        }
        else
        {
            foreach (var t in pets)
            {
                if (t.TargetName != targetName) continue;
                loadPet = ClonePet(t);
                break;
            }
        }
        return loadPet;

    }

    public static void SavePetInfo(PetProperties pet)
    {
        string key = pet.TargetName;
        List<string> petInfo = new List<string>()
        {
            pet.TargetName,
            pet.name,
            pet.Level.ToString(),
            pet.Experience.ToString(),
            pet.Life.ToString(),
            pet.Hungry.ToString(),
            pet.Happiness.ToString(),
            pet.Cleanness.ToString(),
        };
        PlayerPrefsX.SetStringList(key, petInfo);
    }
    private static PetProperties LoadPetInfo(string key)
    {
        List<string> petInfo = PlayerPrefsX.GetStringList(key);
        PetProperties loadPet = new PetProperties()
        {
            TargetName = petInfo[0],
            name = petInfo[1],
            Level = int.Parse(petInfo[2]),
            Experience = int.Parse(petInfo[3]),
            Life = int.Parse(petInfo[4]),
            Hungry = int.Parse(petInfo[5]),
            Happiness = int.Parse(petInfo[6]),
            Cleanness = int.Parse(petInfo[7]),
        };
        return loadPet;

    }
}
