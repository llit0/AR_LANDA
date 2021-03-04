using System;

[Serializable]
public abstract class Person
{
   public int id;
   public int[] position = new int[2]; 
   public int[] velocity = new int[2];
}
