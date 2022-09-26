using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Major_Assignment_2_Aria_Taghizade
{
    public class Dog
    {
        //properties of the dogs in the shelter.

        public int dogId;
        public string name;
        public int age;
        public string breed;
        public char sex;
        public bool foundHome =false;
        
        //Constructer of the class.(foundHome status is false by default, we assume that the dog doesn't have a house.)
        public Dog(int dogId, string name, int age, string breed, char sex)
        {
            this.dogId = dogId;
            this.name = name;
            this.age = age;
            this.breed = breed;
            this.sex = sex;
            
        }

        public int getId()
        {
            return dogId;
        }
        public String getName()
        {
            return name;
        }
        public int getAge()
        {
            return age;
        }
        public String getBreed()
        {
            return breed;
        }
        public char getSex()
        {
            return sex;
        }
        public bool getHomeStatus()
        {
            return foundHome;
        }
        //This method sets the foundHome value to whatever is passed to it.
        public void setHomeStatus(bool status)
        {
            foundHome = status;
            
        }
        //This method returns the information about the dog.
        public String getInfo()
        {
            String gender;
            String pronoun;
            String homestatus;
            //Simple logic to find the pronoun of the dog.(So, we can have a nicer look.)
            if (sex.Equals('m')) {
                gender = "male";
                pronoun = "He";
            }
            else
            {
                gender = "female";
                pronoun = "She";

            }
            if (foundHome == false)
            {
                homestatus = "has not found";
            } else homestatus = "has";
            //make a string that describes the dog's info, and return it.
            String info = $"{name} is a {breed} with the ID of {dogId}, {pronoun} is a {gender} dog. {pronoun} is {age} years old. {pronoun} {homestatus} a house.";
            return info;
        }
    }
}
