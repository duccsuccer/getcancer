using phone;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        List<Phone> phonelist = InitialisePhones();
        while (true)
        {
            Menu();
            int option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                DisplayOutput(phonelist);
            }
            else if (option == 2)
            {
                Console.WriteLine("Update Phone Usage\n" +
                    "--------------------");
                Console.Write("Enter phone no: ");
                string pNo = Console.ReadLine();
                UpdateUsage(phonelist, pNo);
            }
            else if (option == 0) 
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
    static List<Phone> InitialisePhones()
    {
        string[] phonestuff = File.ReadAllLines("PhoneDetails.csv");
        List<Phone> phonelist = new List<Phone>();
        for (int i = 1; i < phonestuff.Length; i++)
        {
            string[] phones = phonestuff[i].Split(",");
            string num = phones[0];
            int usage = Convert.ToInt32(phones[1]);
            string plan = phones[2];
            Phone xphone = new(num, usage, plan);
            phonelist.Add(xphone);
        }
        return phonelist;
    }

    static void Menu()
    {
        Console.WriteLine("[1] Display Phone Details");
        Console.WriteLine("[2] Update Phone Usage");
        Console.WriteLine("[0] Exit");
        Console.Write("Option: ");
    }
    static void DisplayOutput(List<Phone> phonelist)
    {
        Console.WriteLine("{0,-3} {1,-6} {2,-13} {3,-10}", "PhoneNo", "Usage", "PlanType", "PhoneCharge($)");
        foreach (Phone phones in phonelist)
        {
            double charge = phones.CalculateCharge();
            Console.WriteLine($"{phones.PhoneNum,-3} {phones.Usage,-6} {phones.PlanType,-13} {charge,-10:F2}");
        }
    }
    static Phone? Search(List<Phone> phonelist, string pNo)
    {
        for (int i = 0; i < phonelist.Count; i++)
        {
            if (phonelist[i].PhoneNum == pNo)
            {
                return phonelist[i];
            }
        }
        return null;
    }
    static void UpdateUsage(List<Phone> phonelist, string pNo)
    {
        Phone updphone = Search(phonelist, pNo);
        if (updphone != null)
        {
            Console.WriteLine($"Current usage: {updphone.Usage}");
            Console.Write("Enter new usage: ");
            int newuse = Convert.ToInt32(Console.ReadLine());
            updphone.Usage = newuse;
            Console.WriteLine("The new usage is updated successfully");
            DisplayOutput(phonelist);
        }
        else
        { Console.WriteLine("Phone not found!"); }
    }

}

