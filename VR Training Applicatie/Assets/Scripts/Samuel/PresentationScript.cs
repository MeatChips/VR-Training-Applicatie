using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PresentationScript : MonoBehaviour
{
    public GameObject imagePrefab;
    public Transform imageContainer;
    public Button pickFolderButton;
    public Button nextImageButton;

    private string[] imagePaths;
    private int currentImageIndex;
    private string currentFolderPath;

    private void Start()
    {
        pickFolderButton.onClick.AddListener(PickImageFolder);
        nextImageButton.onClick.AddListener(LoadNextImage);
    }

    public void PickImageFolder()
    {
        string path = UnityEditor.EditorUtility.OpenFolderPanel("Select Image Folder", "", "");
        if (path.Length != 0)
        {
            currentFolderPath = path;
            imagePaths = Directory.GetFiles(path, "*.png");
            currentImageIndex = 0;
            if (imagePaths != null && imagePaths.Length > 0)
            {
                string firstImagePath = imagePaths[currentImageIndex];
                LoadImageFromFile(firstImagePath);
            }
            else
            {
                Debug.LogError("No PNG images found in the selected folder.");
            }
        }
    }

    public void LoadNextImage()
    {
        if (imagePaths != null && imagePaths.Length > 0)
        {
            string imagePath = imagePaths[currentImageIndex];
            LoadImageFromFile(imagePath);

            currentImageIndex++;
            if (currentImageIndex >= imagePaths.Length)
            {
                currentImageIndex = 0;
            }
        }
        else
        {
            Debug.LogError("No PNG images found in the selected folder.");
        }
    }

    private void LoadImageFromFile(string filePath)
    {
        byte[] bytes = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);

        CreateImageGameObject(texture);
    }

    private void CreateImageGameObject(Texture2D texture)
    {
        // Remove any existing images from the container
        foreach (Transform child in imageContainer)
        {
            Destroy(child.gameObject);
        }

        // Create a new image game object with the texture
        GameObject imageGO = Instantiate(imagePrefab, imageContainer);
        Image image = imageGO.GetComponent<Image>();
        image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
    }
}
