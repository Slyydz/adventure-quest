using System;

public class Hat
{
    public int ShininessLevel { get; set; }

    public string ShininessDescription { get; set; }

    public Hat(int shininessLevel)
    {
        ShininessLevel = shininessLevel;

        switch (ShininessLevel)
        {
            case < 2:
                ShininessDescription = "dull";
                break;
            case int ShininessLevel when (ShininessLevel > 2 && ShininessLevel < 5):
                ShininessDescription = "noticeable";
                break;
            case int ShininessLevel when (ShininessLevel > 6 && ShininessLevel < 9):
                ShininessDescription = "bright";
                break;
            case > 9:
                ShininessDescription = "blinding";
                break;
        }
    }
}