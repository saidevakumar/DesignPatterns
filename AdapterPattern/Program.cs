//The adapter converts the interface of a class into another interface that clients expect. It allows classes to work together that
//couldn't otherwise because of incompatible interfaces.
public abstract class Duck
{
    public abstract void quack();

    public abstract void fly();
}

public class MallardDuck:Duck
{
    public override void quack(){
        Console.WriteLine("MallardDuck.quack");
    }

    public override void fly(){
        Console.WriteLine("MallardDuck.fly");
    }

}

//This class is the adapter which fits the american plug with european socket.
public class DropAdapter:Duck
{
    Drone rone;

    public DropAdapter()
    {
        rone = new SuperDrone();
    }

    public override void quack(){
        rone.beep();
    }

    public override void fly(){
        rone.spin_rotors();
        rone.take_off();
    }

}

public abstract class Drone
{
    public abstract void beep();

    public abstract void spin_rotors();

    public abstract void take_off();

}

public class SuperDrone : Drone
{
    public override void beep()
    {
        Console.WriteLine("SuperDrone.Beep");
    }

    public override void spin_rotors()
    {
        Console.WriteLine("SuperDrone.spin_rotors");
    }

    public override void take_off()
    {
        Console.WriteLine("SuperDrone.take_off");
    }
}