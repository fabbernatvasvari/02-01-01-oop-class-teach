using SchoolClassManagmentProject.Models;

Console.WriteLine("=== SchoolClass példák ===\n");

var emptyClass = new SchoolClass();
Console.WriteLine("Üres konstruktorral létrehozott osztály:");
Console.WriteLine(emptyClass);
Console.WriteLine();

var class11B = new SchoolClass(11, 'b', 12);
Console.WriteLine("Paraméteres konstruktorral létrehozott osztály:");
Console.WriteLine(class11B);
Console.WriteLine();

Console.WriteLine($"Grade: {class11B.Grade}");
Console.WriteLine($"GradeLetter: {class11B.GradeLetter}");
Console.WriteLine($"LastGrade: {class11B.LastGrade}");
Console.WriteLine($"Name: {class11B.Name}");
Console.WriteLine($"HasGraduated: {class11B.HasGraduated}");
Console.WriteLine($"IsGraduate: {class11B.IsGraduate}");
Console.WriteLine($"IsActive: {class11B.IsActive}");
Console.WriteLine();

class11B.Grade = 12;
Console.WriteLine("Évfolyam átállítása setterrel:");
Console.WriteLine(class11B);
Console.WriteLine();

Console.WriteLine("LastGrade módosítása metódussal:");
class11B.SetLastGrade(13);
Console.WriteLine(class11B);
Console.WriteLine();

var class10A = new SchoolClass(10, 'A', 12);
Console.WriteLine("Kezdeti állapot:");
Console.WriteLine(class10A);

Console.WriteLine("AdvanceGrade hívás után:");
class10A.AdvanceGrade();
Console.WriteLine(class10A);
Console.WriteLine();

Console.WriteLine("Érvényes osztály betűjelek (static field):");
foreach (var letter in SchoolClass.ValidGradeLetters)
{
    Console.Write(letter + " ");
}
Console.WriteLine("\n");

Console.WriteLine("ToString() eredménye:");
Console.WriteLine(class11B.ToString());
Console.WriteLine();

Console.WriteLine("=== DEMÓ vége ===");
