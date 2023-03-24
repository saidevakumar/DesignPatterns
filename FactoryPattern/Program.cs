//A factory method design pattern defines an interface for creating an object, but let subclasses decide which class to instantiate.
//This pattern lets a class defer instantiation to subclasses.
PacificCalendar pc = new PacificCalendar();
pc.createCalendar();
pc.print();

public abstract class Calendar
{
    protected Zone? zone;

    public void print()
    {
        if (zone != null)
        {
            Console.WriteLine("Zone {0}",zone.getDisplayName());
        }
        else
        {
            Console.WriteLine("Zone is null");
        }
    }
    public abstract Zone createCalendar();
}

public class PacificCalendar : Calendar
{
    public override Zone createCalendar()
    {
        zone = ZoneFactory.CreateZone("Pacific");
        return zone;
    }
}


public class ZoneFactory
{
    public static Zone? CreateZone(string zoneid)
    {
        Zone? zn = null;

        if (zoneid == "Eastern")
        {
            zn = new ZoneUSEastern();
        }
        else if (zoneid == "Central")
        {
            zn = new ZoneUSCentral();
        }
        else if (zoneid == "Mountain")
        {
            zn = new ZoneUSMountain();
        }
        else if (zoneid == "Pacific")
        {
            zn = new ZoneUSPacific();
        }

        return zn;
    }
}

public abstract class Zone
{
    protected string displayName = string.Empty;
    protected string offset = string.Empty;

    public string getDisplayName()
    {
        return displayName;
    }

    public string getOffset()
    {
        return offset;
    }
}

public class ZoneUSEastern : Zone
{
    public ZoneUSEastern()
    {
        displayName = "US Eastern";
        offset = "USEastern";
    }
}

public class ZoneUSCentral : Zone
{
    public ZoneUSCentral()
    {
        displayName = "US Central";
        offset = "USCentral";
    }
}


public class ZoneUSMountain : Zone
{
    public ZoneUSMountain()
    {
        displayName = "US Mountain";
        offset = "USMountain";
    }
}


public class ZoneUSPacific : Zone
{
    public ZoneUSPacific()
    {
        displayName = "US Pacific";
        offset = "USPacific";
    }
}