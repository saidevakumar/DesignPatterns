// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Pizza pza = new Pizza();
Console.WriteLine(pza.getDescription());

ThinCrustPizza tPza = new ThinCrustPizza();
ThickCrustPizza thickPza = new ThickCrustPizza();

Cheese top = new Cheese(tPza);
Console.WriteLine(top.cost());


public class Pizza
{
    public virtual string getDescription()
    {
        return "Pizza";
    }

    public virtual int cost()
    {
        return 10;
    }
}

public class ThinCrustPizza:Pizza
{
    public override string getDescription()
    {
        return "Thin Crust";
    }

    public override int cost()
    {
        return base.cost() + 1;
    }
}

public class ThickCrustPizza:Pizza
{
    public override string getDescription()
    {
        return "Thick Crust";
    }

    public override int cost()
    {
        return base.cost() + 2;
    }
}

public abstract class Topping : Pizza
{
    protected Pizza pizza;

    public Topping(Pizza piz)
    {
        this.pizza = piz;
    }

    public override string getDescription()
    {
        return pizza.getDescription();
    }

    public override int cost()
    {
        return pizza.cost();
    }
}

public class Cheese : Topping
{
    public Cheese(Pizza piz) : base(piz)
    {

    }

    public override string getDescription()
    {
        return pizza.getDescription();
    }

    public override int cost()
    {
        return pizza.cost() + 2;
    }
}

public class Olives : Topping
{
    public Olives(Pizza piz) : base(piz)
    {
        
    }

    public override string getDescription()
    {
        return pizza.getDescription();
    }

    public override int cost()
    {
        return pizza.cost() + 3;
    }
}

public class Peppers : Topping
{
    public Peppers(Pizza piz) : base(piz)
    {
        
    }

    public override string getDescription()
    {
        return pizza.getDescription();
    }

    public override int cost()
    {
        return pizza.cost() + 4;
    }
}

