using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PetPropertiesHandler(PetInfoProperties petInfoProperties);

public class PetController : MonoBehaviour
{
    
    public List<PetInfoProperties> allPets = new List<PetInfoProperties>();
    public float countDownLife;
    public float countDownHungry;
    public float countDownHappiness; 
    public float countDownCleanness;
    public Transform gridCanvasPet;
    public GameObject baseCanvasPet;

    
    private void Update()
    {
        if (allPets.Count <= 0) return;
        countDownLife += Time.deltaTime;
        countDownHungry += Time.deltaTime;
        countDownHappiness += Time.deltaTime;
        countDownCleanness += Time.deltaTime;
        

    }
    public void LoadPetByTarget(GameObject obj, string targetName)
    {
        if (HasPet(targetName) == false)
        {
            PetInfoProperties newPet = new PetInfoProperties
            {
                pet = PetCreator.GetPetByTargetName(targetName), 
                petObj = obj
            };
            allPets.Add(newPet);
        }
        else
        {
            print("esta mascota ya la tienes añadida");
        }
    }
    
    
    private void AddFood(PetInfoProperties petInfo)

    {
        if(petInfo.pet.Hungry < 100)
        {
            petInfo.pet.Hungry++;
            //UpdateCanvasPet(_petInfo);
        }
    }
    private void AddHappiness(PetInfoProperties petInfo)

    {
        if (petInfo.pet.Happiness < 100)
        {
            petInfo.pet.Happiness++;
           // UpdateCanvasPet(_petInfo);
        }
    }
    private void AddCleannes(PetInfoProperties petInfo)

    {
        if (petInfo.pet.Cleanness < 100)
        {
            petInfo.pet.Cleanness++;
            //UpdateCanvasPet(_petInfo);
        }
    }

    private void AddExperience(PetInfoProperties petInfo)
    {
        if (petInfo.pet.Experience < 100)
        {
            petInfo.pet.Experience += 10;
           // UpdateCanvasPet(petInfo);
        }
    }
    

    private bool HasPet(string targetName)
    {
        foreach (var t in allPets)
        {
            if (t.pet.TargetName == targetName)
            {
               
                return true;
                
            }
        }

        return false;
    }

    public void UnloadPetByTarget(string targetName)
    {
        if (HasPet(targetName) != true) return;
        for (int i = 0; i < allPets.Count; i++)
        {
            if (allPets[i].pet.TargetName != targetName) continue;
            allPets.RemoveAt(i);
            
            break;
        }
    }
   

    public void AddLife()
    {
        for (int i = 0; i < allPets.Count; i++)
        {
            if (allPets[i].pet.Hungry >= 100 && allPets[i].pet.Life < 100)
            {
                allPets[i].pet.Life++;
                PetCreator.SavePetInfo(allPets[i].pet);
            

            }

        }
    }
    public void RemoveLife(PetInfoProperties _petInfo)
    {
        _petInfo.pet.Life--;
        if (_petInfo.pet.Life < 0)
        {
            _petInfo.pet.Life = 0;
        }
        PetCreator.SavePetInfo(_petInfo.pet);
      
    }


    public void RemoveHungry()
    {
        for (int i = 0; i < allPets.Count; i++)
        {
            allPets[i].pet.Hungry--;
            if (allPets[i].pet.Hungry <= 0)
            {
                allPets[i].pet.Hungry = 0;
                RemoveLife(allPets[i]);
            }
            PetCreator.SavePetInfo(allPets[i].pet);
     
        }
    }
    public void RemoveHappinness()
    {
        for (int i = 0; i < allPets.Count; i++)
        {
            allPets[i].pet.Happiness--;
            if (allPets[i].pet.Happiness <= 0)
            {
                allPets[i].pet.Happiness = 0;
                RemoveLife(allPets[i]);
            }
            PetCreator.SavePetInfo(allPets[i].pet);
        }
    }
    public void RemoveCleanness()
    {
        for (int i = 0; i < allPets.Count; i++)
        {
            allPets[i].pet.Cleanness--;
            if (allPets[i].pet.Cleanness <= 0)
            {
                allPets[i].pet.Cleanness = 0;
                RemoveLife(allPets[i]);
            }
            PetCreator.SavePetInfo(allPets[i].pet);
          
        }
    }
}