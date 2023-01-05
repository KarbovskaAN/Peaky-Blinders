using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class Field : MonoBehaviour
{
   public GameObject GreenButton;
   public GameObject YellowButton;
   public GameObject RedButton;
   public GameObject GreyButton;

   private int Width ;
   private int Height ;

   private int CountGreenButton ;
   private int CountYellowButton ;
   private int CountRedButton ;
   private int CountGreyButton;
   
   public  List <Button> Buttons ;

   private int _countAllButton;

   private int _currentButton;
   private int _countForCurrentButton;

   public void GenerateField(int width, int height, int greenButton, int yellowButton, int redButton)
   {
      Width = width;
      Height = height;
      CountGreenButton = greenButton;
      CountYellowButton = yellowButton;
      CountRedButton = redButton;
      
      CountingGreyButtons();
      CreatAllButtons();
      MixAllButtons(); 
      MixAllButtons();
      CreateField();
   }

   void CountingGreyButtons()
   {
      _countAllButton = Width * Height;
      CountGreyButton = _countAllButton - (CountGreenButton + CountRedButton + CountYellowButton);
   }

   void CreatAllButtons()
   { 
      for (int i = 0; i < CountGreenButton; i++)
      {
         CreatOneButton( ButtonTypes.Green);
      }
      for (int i = 0; i < CountYellowButton; i++)
      { 
         CreatOneButton( ButtonTypes.Yellow);
      }
      for (int i = 0; i < CountGreyButton; i++)
      {
         CreatOneButton( ButtonTypes.Grey);
      }
      for (int i = 0; i < CountRedButton; i++)
      {
         CreatOneButton( ButtonTypes.Red);
      }
   }

   private void CreatOneButton( ButtonTypes type)
   {
      GameObject Button = GreyButton;

      if (type == ButtonTypes.Green)
      {
         Button = GreenButton;
      }

      if (type == ButtonTypes.Yellow)
      {
         Button = YellowButton;
      }

      if (type == ButtonTypes.Red)
      {
         Button = RedButton;
      }

      GameObject clone = Instantiate(Button);
      
      Button buttonScript = clone.GetComponent<Button>();
      Buttons.Add(buttonScript);
   }

   void MixAllButtons()
   {
      Random RND = new Random();
      
      for (int i = Buttons.Count - 1; i >= 1; i--)
      {
         int j = RND.Next(i + 1);
         var temp = Buttons[j];
         Buttons[j] = Buttons[i];
         Buttons[i] = temp;
      }
   }

   void CreateField()
   {
      int index = 0;
         
      for (int x = 0; x < Width; x++)
      {
         for (int z = 0; z < Height; z++)
         {
            Buttons[index].transform.position = new Vector3(x * 1, 0, z * 1);
            index += 1;
         }
      }
   }

   public void DeletedAllButtons()
   {
      for (int i = 0; i < Buttons.Count; i++)
      {
         Destroy(Buttons[i].gameObject);
      }
      Buttons.Clear();
   }
}