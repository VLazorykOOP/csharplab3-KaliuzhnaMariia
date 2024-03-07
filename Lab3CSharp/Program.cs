namespace Lab3CSharp
{

    class Trapeze{
        private int a, b, h;
        private string c;

        public Trapeze(int a, int b, int h, string c){
            this.a = a;
            this.b = b;
            this.h = h;
            this.c = c;
        }

        public double Perimeter(){
            double rez = a + b + 2 * Math.Sqrt(Math.Pow(h, 2) + Math.Pow((b - a) / 2.0, 2));
            return (Math.Round(rez, 2));
        }

        public double Area(){
            double rez = (a + b) * h / 2;
            return (Math.Round(rez, 2));
        }

        public bool isSquare(){
            return a == b && a == h;
        }

        public int A{
            get {return a;}
            set { a = value;}
        }

        public int B{
            get {return b;}
            set { b = value;}
        }

        public int H{
            get {return h;}
            set { h = value;}
        }

        public string C{
            get {return c;}
        }

        public override string ToString()
        {
            return $"Trapeze: side a={a}, side b={b}, height ={h}, color={c}";
        }

    }

    class Test{
        public string Subject {get; set;}
        //public string HardLevel {get; set;}
        public string StudentSurename {get; set;}
        public int NumberOfQuestions{ get; set;}

        public virtual void Show(){
            Console.WriteLine($"Test: subject = {Subject}, student's surname = {StudentSurename}, number of questions = {NumberOfQuestions}");
        }
    }

    class Exam : Test{
        public int HighestScore {get; set;}

        public override void Show(){
            base.Show();
            Console.WriteLine($"Exam: the maximum score = {HighestScore}");
        }
    }

    class FinalExam : Test{
        public int NumberOfModules {get; set;}

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Final exam: number of modules = {NumberOfModules}");
        }
    }

    class Trial : Test{
        public double Lasting {get; set;}
        public int NumberOfAttempts {get; set;}

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Trial: time in hours = {Lasting}, number of attempts = {NumberOfAttempts}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 3 (variant 7)");
            Console.Write("Enter the number of task (1 - 2): ");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice){
                case 1:{
                    Trapeze[] trapezeArray = new Trapeze[]{
                        new Trapeze(10, 6, 5, "red"),
                        new Trapeze(8, 8, 8, "green"),
                        new Trapeze(12, 9, 7, "blue"),
                        new Trapeze(4, 4, 4, "yellow")
                    };
                    foreach (Trapeze trapeze in trapezeArray){
                        Console.WriteLine(trapeze);
                        Console.WriteLine("The perimeter of trapeze: " + trapeze.Perimeter());
                        Console.WriteLine("The area of trapeze: " + trapeze.Area());

                        if(trapeze.isSquare()){
                            Console.WriteLine("This trapeze is square!");
                        }
                        Console.WriteLine();
                    }
                } break;
                case 2:{
                    Test[] testsArray = new Test[]{
                        new Test{Subject = "Math", StudentSurename = "Collins", NumberOfQuestions = 10},
                        new Exam{Subject = "Physics", StudentSurename = "Traviks", NumberOfQuestions = 15, HighestScore = 40},
                        new FinalExam{Subject = "English", StudentSurename = "Vessender", NumberOfQuestions = 5, NumberOfModules = 5},
                        new Trial{Subject = "IT", StudentSurename = "Yetter", NumberOfQuestions = 25, Lasting = 1.5, NumberOfAttempts = 2}
                    };

                     testsArray = testsArray.OrderBy(t => t.NumberOfQuestions).ToArray();

                    foreach (Test test in testsArray){
                        test.Show();
                        Console.WriteLine();
                    }
                }break;
                default:{
                    Console.WriteLine("Invalid choice!");
                    break;
                }
            }
        }
    }
}
