using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour{
    Vehicle v;
    Bicycle b;
    Car c1, c2;
    List<Vehicle> myVehicles;
    // Start is called before the first frame update
    void Start(){
        //Because of them all being of part of Vehicle Class, you could add all of them for type list of Vehicles
        myVehicles = new List<Vehicle>();
        //Can makes an instance of all classes of vehicles and inheritors
        //v = new Vehicle(0); //cannot modify a class of Vehicle anymore because it is abstract
        b = new Bicycle(2);
        c1 = new Car("Jeep", "Gladiator", 5);
        c2 = new Car("Honda", "Civic", 4);

        //myVehicles.Add(v);
        myVehicles.Add(b);
        myVehicles.Add(c1);
        myVehicles.Add(c2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//Base Class vehicle
abstract class Vehicle : MonoBehaviour{
    public int numberOfWheels;
    public Vehicle(int numberOfWheels){
        this.numberOfWheels = numberOfWheels;
    }

    //abstract means you have to overide this function, and this function cannot be defined
    public abstract void Go();
    //virtual means that you have a choice to overide this function, but you can also leave it as is
    //If you don't put virtual, it does not allow you overide
    public virtual void Explode(){
        Console.WriteLine("You vehicle has exploded");
    }
}

//Bike inherits from Vehicle
class Bicycle : Vehicle{
    //Because Vehicle already handles number of wheels, you pull it from its base class
    public Bicycle(int numberOfWheels) : base(numberOfWheels){
    }

    public override void Go(){
        Debug.Log("Your bike started going");
    }
}

//Car inherits from type Vehicle
class Car : Vehicle{
    string make;
    string model;
    public Car(string make,  string model, int numberOfWheels) : base(numberOfWheels){
        this.make = make;
        this.model = model;
    }//When ther are multiple values of the same type, the one tou pass in to base will be the one pulled from base
    public Car(string make,  string model, int speed, int numberOfWheels) : base(numberOfWheels){
        this.make = make;
        this.model = model;
    }

    public override void Go(){
        Debug.Log("Yous car has started going");
    }
    public override void Explode(){
        base.Explode();//Uses the bas Explode function
        Debug.Log("Actully, it was your Car that exploded.");
    }
}
