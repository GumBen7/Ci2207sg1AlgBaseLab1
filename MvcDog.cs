class DogController {
    private Dog Model;
    private DogView View;
    public DogController(Dog model, DogView view) {
        this.Model = model;
        this.View = view;
        this.View.Appear(false);
        if (this.View.WaitAndTake() == "🦴") {
            this.View.AppearEating();
            this.Model.SetFull(true);
            this.View.Appear(true);
            this.View.WaitAndTake();
        }
    }
    public void Name(string newName) {
        if (Model.GetName() == null) {
            Model.SetName(newName);
        }
    }
}

class DogView {
    public void Appear(bool isFull) {
        if (!isFull) {
            System.Console.WriteLine("૮⍝• ᴥ •⍝ა");
        }
        else {
            System.Console.WriteLine("૮ • ᴥ •ა ");
        }
        
    }
    public string WaitAndTake() {
        return System.Console.ReadLine();
    }  
    public void AppearEating() {
        System.Console.WriteLine("૮˶• ﻌ •˶ა\n./づ~ 🦴");
    }  
}

class Dog {
    private bool IsFull;
    public void SetFull(bool isFull) {
        this.IsFull = isFull;
    }
    private string? Name;
    public void SetName(string name) {
        this.Name = name;
    }
    public string? GetName() {
        return this.Name;
    }
}
