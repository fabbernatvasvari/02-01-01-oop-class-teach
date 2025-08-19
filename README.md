# Feladat: SchoolClass modell és demó konzolprogram

Ez a feladat egy iskolai osztályt leíró modell (SchoolClass)
elkészítését mutatja be lépésről lépésre. Egy teljesen új .NET konzol
projektben kell a diákoknak elkészíteniük a kódot. Minden részfeladat
után közvetlenül megtalálod a megoldás kódját is.

## 0) Előkészületek

Hozz létre új .NET konzolos projektet SchoolClassManagmentProject néven.
Adj hozzá egy Models mappát.

## 1) SchoolClass osztály

Hozd létre a Models mappában a SchoolClass.cs fájlt, és benne az üres
osztályt.

## 2) Fieldek

Vedd fel a privát mezőket: \_grade (byte), \_lastGrade (byte),
\_gradeLetter (char, readonly).

## 3) Statikus adattag

Adj hozzá statikus readonly tömböt az érvényes betűjelekhez: {
\'A\',\'B\',\'C\',\'D\' }.

## 4) Getter-only auto-property

Adj hozzá CreatedAt tulajdonságot: public DateTime CreatedAt { get; } =
DateTime.Now;

## 5) Konstruktor (paraméteres)

Hozz létre paraméteres konstruktort, amely validálja a betűjelet és
beállítja a mezőket.

## 6) Konstruktor-láncolás

Hozz létre üres konstruktort, amely a paraméteresre hivatkozik
alapértékekkel (byte.MinValue, ValidGradeLetters\[0\]).

## 7) Property-k

Hozd létre a Grade (get/set), GradeLetter (csak get), LastGrade (get +
private set) property-ket.

## 8) Kifejezésalapú property-k

Add meg a Name, HasGraduated, IsGraduate, IsActive property-ket
kifejezésalapú formában.

## 9) Metódusok

Implementáld a SetLastGrade(byte newGrade) metódust (ellenőrzés +
kivétel), és az AdvanceGrade() metódust (léptetés).

## 10) Saját kivétel

Hozz létre LastGradeModificationErrorException.cs fájlt a Models
mappában a feladatleírás szerinti kivételosztállyal.

## 11) ToString() override

Írd felül a ToString() metódust, hogy értelmes szöveget adjon vissza az
osztály állapotáról.

## 12) Destruktor

Tedd be a \~SchoolClass() finalizert, amely kiírja a példány megszűnését
(oktatási célra).

## 13) Program.cs

Másold be az alábbi Program.cs kódot a projekt fő Program.cs fájljába,
és futtasd.

### Megoldás:

using SchoolClassManagmentProject.Models;\
\
Console.WriteLine(\"=== SchoolClass példák ===\\n\");\
\
var emptyClass = new SchoolClass();\
Console.WriteLine(\"Üres konstruktorral létrehozott osztály:\");\
Console.WriteLine(emptyClass);\
Console.WriteLine();\
\
var class11B = new SchoolClass(11, \'b\', 12);\
Console.WriteLine(\"Paraméteres konstruktorral létrehozott osztály:\");\
Console.WriteLine(class11B);\
Console.WriteLine();\
\
Console.WriteLine(\$\"Grade: {class11B.Grade}\");\
Console.WriteLine(\$\"GradeLetter: {class11B.GradeLetter}\");\
Console.WriteLine(\$\"LastGrade: {class11B.LastGrade}\");\
Console.WriteLine(\$\"Name: {class11B.Name}\");\
Console.WriteLine(\$\"HasGraduated: {class11B.HasGraduated}\");\
Console.WriteLine(\$\"IsGraduate: {class11B.IsGraduate}\");\
Console.WriteLine(\$\"IsActive: {class11B.IsActive}\");\
Console.WriteLine();\
\
class11B.Grade = 12;\
Console.WriteLine(\"Évfolyam átállítása setterrel:\");\
Console.WriteLine(class11B);\
Console.WriteLine();\
\
Console.WriteLine(\"LastGrade módosítása metódussal:\");\
class11B.SetLastGrade(13);\
Console.WriteLine(class11B);\
Console.WriteLine();\
\
var class10A = new SchoolClass(10, \'A\', 12);\
Console.WriteLine(\"Kezdeti állapot:\");\
Console.WriteLine(class10A);\
\
Console.WriteLine(\"AdvanceGrade hívás után:\");\
class10A.AdvanceGrade();\
Console.WriteLine(class10A);\
Console.WriteLine();\
\
Console.WriteLine(\"Érvényes osztály betűjelek (static field):\");\
foreach (var letter in SchoolClass.ValidGradeLetters)\
{\
Console.Write(letter + \" \");\
}\
Console.WriteLine(\"\\n\");\
\
Console.WriteLine(\"ToString() eredménye:\");\
Console.WriteLine(class11B.ToString());\
Console.WriteLine();\
\
Console.WriteLine(\"=== DEMÓ vége ===\");
