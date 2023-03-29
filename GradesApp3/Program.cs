using GradesApp3;

Console.WriteLine("Witam w Programie Szkolne Oceny");
Console.WriteLine("=================================================");
Console.WriteLine();

var studentInMemory = new StudentInMemory("Krzysiek", "Markowkski");

var studentInFile = new StudentInFile("Antek", "Kobuz");

studentInMemory.GradeAdded += StudentGradeAdded;

studentInFile.GradeAdded -= StudentGradeAdded;

while (true)
{
    Console.WriteLine("Wybierz studenta: " +

        "1 - student w pamięci; " +

        "2 - student w pliku; " +

        "q - kończy liczenie, lub wychodzi z programu");


    var userChoice = Console.ReadLine();

    if (userChoice == "q")
    {
        Environment.Exit(0);
    }

    IStudent choseStudent = userChoice switch
    {
        "1" => studentInMemory,

        "2" => studentInFile,

        _ => default
    };

    if (choseStudent == default)
    {
        Console.WriteLine("Nieprawidłowy wybór");

        continue;
    }
    while (true)
    {
        Console.WriteLine("Podaj kolejną ocenę studenta: ");

        var input = Console.ReadLine();

        if (input == "q")
        {
            break;
        }
        else
        {
            try
            {
                choseStudent.AddGrade(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception catched: {e.Message}");
            }
        }

        var statistics = choseStudent.GetStatistics();

        Console.WriteLine($"Average: {statistics.Average}");

        Console.WriteLine($"Min: {statistics.Min}");

        Console.WriteLine($"Max: {statistics.Max}");
    }
}

void StudentGradeAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano nową ocenę");
}
