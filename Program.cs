/*TODO
All arrows have 3 parts:
[NAME]                Arrowhead 
    [TYPE]      Steel, Wood, Obsidian
   [Price]        10g,   3g,       5g

[NAME]                Shaft
  [Length]          60 - 100cm
   [Price]           0.05g/cm

[NAME]              Fletchling
    [TYPE]     Plastic, Turkey Feather, Goose Feathers
   [PRICE]         10g,             5g,             3g

- Define a new Arrow class with fields for the arrowhead type, fletchling type, and length
- Allow a user to pick the arrowhead, fletchling type, and length and then create a new Arrow instance.
- Add a GetCost method that returns its cost as a float based on the numbers above, use this to display
  arrow cost.
*/

string? userInput;
Arrows arrow = new();

    Console.WriteLine("                               Arrowhead\n" +
                      "                  Steel,   |    Wood,   |    Obsidian\n" +
                      "                     10g,  |      3g,   |          5g\n" +
                      "--------------------------------------------------------------------\n" +
                      "                                Shaft\n" +
                      "                              60 - 100cm\n" +
                      "                                0.05g/cm\n" +
                      "--------------------------------------------------------------------\n" +
                      "                       Arrowhead\n" +
                      "            Plastic,   |    Goose Feathers,   |    Turkey Feathers\n" +
                      "                10g,  |                 3g,   |                 5g\n" +
                      "--------------------------------------------------------------------\n" +
                      "\n");

    Console.Write("Pick arrowhead type: ");

while(arrow.ArrowheadIsUnknown())
{
    userInput = Console.ReadLine();
    if(UserTypedExit(userInput))
    {
        return;
    }
    arrow.TrySetArrowheadType(userInput, out arrow.arrowhead);
}

    Console.Write("Pick length of arrow shaft (60-100cm): ");

while(!arrow.ArrowShaftIsCorrectLength())
{
    userInput = Console.ReadLine();
    if(UserTypedExit(userInput))
    {
        return;
    }
    arrow.TrySetShaftLength(userInput, out arrow.length);
}

    Console.Write("Pick Fletchling Type: ");
while(arrow.FletchlingIsUnknown())
{
    userInput = Console.ReadLine();
        if(UserTypedExit(userInput))
    {
        return;
    }
    arrow.TrySetFletchlingType(userInput, out arrow.fletchling);
}


Console.WriteLine($"You picked a arrow with a {arrow.arrowhead} arrowhead, \n" +
                  $"with a length of {arrow.length}cm, with {arrow.fletchling} fletchling.\n" +
                  $"The total is: {arrow.GetCost()}g.");


bool UserTypedExit(string userInput)
{
    return userInput.ToLower() == "exit";
}

public class Arrows
{
    public Arrowhead arrowhead;
    public float length;
    public Fletchling fletchling;

    public Arrows()
    {
        this.arrowhead = Arrowhead.Unknown;
        this.length = 0f;
        this.fletchling = Fletchling.Unknown;
    }
    public Arrows(Arrowhead arrowhead, float length, Fletchling fletchling)
    {
        this.arrowhead = arrowhead;
        this.length = length;
        this.fletchling = fletchling;
    }
    
    public enum Arrowhead
    {
        Unknown = 0,
        Steel = 10,
        Wood = 3,
        Obsidian = 5
    }

    public enum Fletchling
    {
        Unknown = 0,
        Plastic = 10,
        TurkeyFeather = 5,
        GooseFeather = 3
    }

    public bool ArrowheadIsUnknown()
    {
        return this.arrowhead == Arrowhead.Unknown;
    }

    public bool ArrowShaftIsCorrectLength()
    {
        return this.length >= 60 && this.length <= 100;
    }
    public bool FletchlingIsUnknown()
    {
        return this.fletchling == Fletchling.Unknown;
    }

    public bool TrySetArrowheadType(string userInput, out Arrowhead arrowheadType)
    {
        switch(userInput.ToLower())
        {
            case "steel":
                arrowheadType = Arrowhead.Steel;
                return true;
            case "obsidian":
                arrowheadType = Arrowhead.Obsidian;
                return true;
            case "wood":
                arrowheadType = Arrowhead.Wood;
                return true;
            default:
                Console.Write("Invalid type, please choose an arrowhead type: ");
                arrowheadType = Arrowhead.Unknown;
                return false;
        }
    }
    
    public bool TrySetShaftLength(string userInput, out float length)
    {
        if(Single.TryParse(userInput, out length))
        {
            if(length >= 60 && length <= 100)
            {
                return true;
            }
        }
        Console.Write("Incorrect Length, please choose length (60-100cm): ");
        return false;
    }
    public bool TrySetFletchlingType(string userInput, out Fletchling fletchlingType)
    {
        switch(userInput.ToLower())
        {
            case "plastic":
                fletchlingType = Fletchling.Plastic;
                return true;
            case "goose feather":
            case "goosefeather":
                fletchlingType = Fletchling.GooseFeather;
                return true;
            case "turkey feather":
            case "turkeyfeather":
                fletchlingType = Fletchling.TurkeyFeather;
                return true;
            default:
                fletchlingType = Fletchling.Unknown;
                Console.Write("Invalid type, please choose an feltchling type: ");
                return false;
        }
    }

    public float GetCost()
    {
        return (int)this.arrowhead + (int)this.fletchling + (this.length * 0.05f);
    }
}