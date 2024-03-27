using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ImageManagerSingleton : MonoBehaviour
{

    public static ImageManagerSingleton Instance;

    // Dictionary to hold the image data
    Dictionary<string, Dictionary<string, List<string>>> jobImages = new Dictionary<string, Dictionary<string, List<string>>>();


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
 
    public void AddImageToJob(string jobID, string insID, string imagePath)
    {
        if (!jobImages.ContainsKey(jobID))
        {
            jobImages[jobID] = new Dictionary<string, List<string>>();
        }

        if (!jobImages[jobID].ContainsKey(insID))
        {
            jobImages[jobID][insID] = new List<string>();
        }

        jobImages[jobID][insID].Add(imagePath);

        string filePath = Path.Combine(Application.persistentDataPath, "ImagesData.txt");
        using (StreamWriter writer = new StreamWriter(filePath))
        {
           writer.WriteLine($"{jobID }+{insID },{imagePath}");
                  
        }

    }

    void OnApplicationQuit()
    {
        SaveImageDataToFile();
    }

    // Method to save image data to a text file
    void SaveImageDataToFile()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "ImagesDataBackup.txt");
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var jobEntry in jobImages)
            {
                foreach (var insEntry in jobEntry.Value)
                {
                    foreach (var imagePath in insEntry.Value)
                    {
                        writer.WriteLine($"{jobEntry.Key}+{insEntry.Key},{imagePath}");
                    }
                }
            }
        }
        Debug.Log($"ImageData saved to {filePath}");
    }
}
