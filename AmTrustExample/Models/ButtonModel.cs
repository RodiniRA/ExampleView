using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmTrustExample.Models
{
    public class ButtonModel
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Image { get; set; }
        public string ToolTip { get; set; }

        public ButtonModel(string name, string label, string image, string toolTip)
        {
            Name = name;
            Label = label;
            Image = image;
            ToolTip = toolTip;
        }
    }

    public static class SampleData
    {
        public static List<ButtonModel> ButtonModels { get; set; }
        public static List<ButtonModel> PolicySystemButtons { get; set; }

        public static void Seed()
        {
            if (ButtonModels != null) return;

            ButtonModels = new List<ButtonModel> 
            {
                new ButtonModel("btnDocumentInfo", "Document Info", "Images/testImage.jpg", "OBTAIN AGENT INFORMATION.  ALSO, CHANGE WEB LOGON INFO."),
                new ButtonModel("btnAgentInfo", "Agent Info", "Images/testImage.jpg", "DISPLAYS ALL SETUP INFORMATION ASSOCIATED WITH DOCUMENT")
            };

            PolicySystemButtons = new List<ButtonModel>
            {
                new ButtonModel("btnWC", "Workers Comp", "Images/testImage.jpg", "Opens Workers Comp System"),
                new ButtonModel("btnCPP", "CPP", "Images/testImage.jpg", "Opens CPP System"),
                new ButtonModel("btnSystemX", "System X", "Images/testImage.jpg", "Opens GMAC System"),
                new ButtonModel("btnClaims", "Claims", "Images/testImage.jpg", "Takes you to the claims ana menus."),
                new ButtonModel("btnDL", "Disablility Liability", "Images/testImage.jpg", "Hello, my name is Mr. Puffa")
            };
        }
    }
}
