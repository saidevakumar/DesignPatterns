/*
This pattern defines a one-to-many dependency between objects so that when one object changes state, all of its dependents are notified and 
update automatically.

For easy understanding think about the publisher and subscriber anology or one to many anology.
The subscriber is the observer.
*/

//Publisher
WeatherStation ws = new WeatherStation();

//Subscribers
UserInterface ui = new UserInterface(ws);
Logger log = new Logger(ws);
AlertSystem als = new AlertSystem(ws);

//Update the publisher's temperature.
ws.Temperature = 100;

//Update the publisher's WindSpeed
ws.WindSpeed = 10;

public abstract class WeatherStationObserver
{
    public abstract void update(int newValue, string WhatChanged);
}

interface IWeatherNotify
{
    public void NotifySubscriber(int newValue, string changed);

    public void register(WeatherStationObserver newSubscriber);

    public void deRegister(WeatherStationObserver oldSubscriber);

}

public class WeatherStation: IWeatherNotify
{
    List<WeatherStationObserver> col;

    public WeatherStation()
    {
        col = new List<WeatherStationObserver>();
    }

    int temperature;

    int windspeed;

    int pressure;

    public int Temperature
    {
        set{
            temperature = value;
            NotifySubscriber(temperature,"TEMPERATURE");
        }

        get {
            return temperature;
        }
    }

    public int WindSpeed 
    {
        get{
            return windspeed;
        }
        set{
            windspeed = value;
            NotifySubscriber(windspeed,"WINDSPEED");
        }
    }

    public int Pressure{
        get{
            return pressure;
        }
        set{
            pressure = value;
            NotifySubscriber(pressure,"PRESSURE");
        }
    }

    public void NotifySubscriber(int newValue, string changed)
    {
        foreach(WeatherStationObserver ws in col)
        {
            ws.update(newValue,changed);
        }
    }

    public void register(WeatherStationObserver newSubscriber)
    {
        col.Add(newSubscriber);
    }

    public void deRegister(WeatherStationObserver oldSubscriber)
    {
        col.Remove(oldSubscriber);
    }
}

//This is a concrete observer
public class UserInterface:WeatherStationObserver
{
    WeatherStation ws;

    public UserInterface(WeatherStation weatherstation)
    {
        ws = weatherstation;
        ws.register(this);
    }

    public void display(int newValue, string WhatChanged)
    {

    }

    public override void update(int newValue, string WhatChanged)
    {
        Console.WriteLine(string.Format("Updated Data in UserInterface {0} - {1}",newValue,WhatChanged));
    }
}

public class Logger:WeatherStationObserver
{
    WeatherStation ws;

    public Logger(WeatherStation pws)
    {
        this.ws = pws;
        ws.register(this);
    }

    public void Log()
    {

    }

    public override void update(int newValue, string WhatChanged)
    {
        Console.WriteLine(string.Format("Updated Data in Logger {0} - {1}",newValue,WhatChanged));
    }
}

public class AlertSystem:WeatherStationObserver
{
    WeatherStation ws;

    public AlertSystem(WeatherStation weatherstation)
    {
        ws = weatherstation;
        ws.register(this);
    }

    public void Alert()
    {

    }

    public override void update(int newValue, string WhatChanged)
    {
        Console.WriteLine(string.Format("Updated Data in AlertSystem {0} - {1}",newValue,WhatChanged));
    }
}