
using GradesApp3;

Console.WriteLine("Witam w Programie Szkolne Oceny");
Console.WriteLine("=================================================");
Console.WriteLine();

var studentInMemory = new StudentInMemory("Krzysiek", "Markowkski");
var studentInFile = new StudentInFile("Antek", "Kobuz");
studentInMemory.GradeAdded += StudentGradeAdded;
studentInFile.GradeAdded -= StudentGradeAdded;

Console.WriteLine("Wybierz studenta: 1 - student w pamięci; 2 - student w pliku");
var userChoice = Console.ReadLine();

IStudent choseStudent = userChoice switch
{
    "1" => studentInMemory,
    "2" => studentInFile,
    _ => throw new Exception("Nieprawidłowy wybór")
};

while (true)
{
    Console.WriteLine("Podaj kolejną ocenę studenta: ");
    var input = Console.ReadLine();
    if (input == "q")
    {
        break;
    }
    else if (float.TryParse(input, out var inputGrade))
    {
        try
        {
            choseStudent.AddGrade(inputGrade);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception catched: {e.Message}");
        }
    }
    else
    {
        Console.WriteLine("Nieprawidłowa ocena");
    }
    var statistics = choseStudent.GetStatistics();
    Console.WriteLine($"Average: {statistics.Average}");
    Console.WriteLine($"Min: {statistics.Min}");
    Console.WriteLine($"Max: {statistics.Max}");
}

void StudentGradeAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano nową ocenę");
}
