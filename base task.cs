abstract class Worker
{  public  Worker(string name)
    {
        this.name = name;
       
    }

    public string name;
    public string Position;
    public List<string> WorkDay=new List<string>();
   

    public void Call()
    {
        WorkDay.Add("call ");
    }

    public void WriteCode()
    {
        WorkDay.Add("write code ");
    }

    public void Relax()
    {
        WorkDay.Add("relax ");
    }

    public abstract void FillWorkDay();
};



class Developer: Worker
{
    public Developer(string name):base(name)
    {
      
        Position = "Розробник";
      
        
    }

    public override void FillWorkDay()
    {   
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}

class Manager:Worker
{
    public Manager(string name ):base(name)
    {
    
        Position = "Менеджер";
    }

    private Random random;
    public override void FillWorkDay()
    {
        random = new Random();
        for (int i = 0; i < random.Next(1,10); i++)
        {
            Call();
        }
        Relax();
        for (int i = 0; i < random.Next(1,5); i++)
        {
            Call();
        }
    }
}

class Team
{
    public Team(string name)
    {
        this.name = name;
    }

   
    public string name;
    private List<Worker> listOfWorkers=new List<Worker>();


    public void addNewstuff(Worker obj)
    {
        listOfWorkers.Add(obj);
       
    }


    public void InfoAboutTeam()
    {
        
        Console.WriteLine("Name of team: "+name);
        Console.WriteLine("Workers:");
        foreach (var obj in listOfWorkers)
        {
           Console.WriteLine(obj.name);
            
        }
    
    }

    public void DetailInfo()
    {
        Console.WriteLine($"\nName of team: {name}\nWorkers:");
        
        foreach (var obj in listOfWorkers)
        {   
            obj.FillWorkDay(); 
            Console.Write($"\n{obj.name} - {obj.Position} - ");
            foreach (var task in obj.WorkDay )
            {
                Console.Write(task);
            }
            
        }
    }
}
