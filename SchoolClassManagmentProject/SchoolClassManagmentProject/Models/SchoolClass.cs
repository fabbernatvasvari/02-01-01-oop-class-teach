using System.Reflection;

namespace SchoolClassManagmentProject.Models
{
    /// <summary>
    /// Reprezentál egy iskolai osztályt (pl. 11.A).
    /// </summary>
    /// <remarks>
    /// <para>
    /// Oktatási célokra tartalmaz több OOP mintát: readonly field, getter-only auto-property (immutabilitás),
    /// statikus adattag, konstruktor-láncolás, property-backed field, kifejezésalapú property, ToString() override.
    /// </para>
    /// <para>
    /// </para>
    /// </remarks>
    /// <example>
    /// <code>
    /// var cls1 = new SchoolClass(11, 'b', 12); // kisbetű is megengedett
    /// Console.WriteLine(cls1.Name);            // "11. B"
    /// Console.WriteLine(cls1);                 // ToString()-gel formázott sor
    ///
    /// var cls2 = new SchoolClass();            // 0.A alapértékekkel (ValidGradeLetters[0])
    /// Console.WriteLine(cls2.Name);            // "0. A"
    /// </code>
    /// </example>
    public class SchoolClass
    {
        // --------------------------------------------------------------------
        // Fields (belső állapot). Privát, _camelCase elnevezés.
        // --------------------------------------------------------------------


        /// <summary>
        /// Ozstály évfolyama: 
        /// USA kontextusban: Grade → megfelelő.
        /// UK/magyar kontextusban: inkább Year vagy SchoolYear.
        /// </summary>
        private byte _grade;

        /// <summary>
        /// Osztály betűjele. Readonly mező: csak konstruktorban kaphat értéket.
        /// </summary>
        private readonly char _gradeLetter;

        /// <summary>
        /// Utolsó évfolyam (pl. 12 vagy 13).
        /// </summary>
        private byte _lastGrade;

        // Statikus adattag
        // Nem egy példányhoz tartozik, hanem az osztályhoz.
        // Az osztály összes példánya ugyanazt az értéket látja és használja.
        /// <summary>
        /// Érvényes osztály-betűjelek. Bemeneti validációhoz használjuk.
        /// </summary>
        public static readonly char[] ValidGradeLetters = { 'A', 'B', 'C', 'D' };

        // Public API-k
        // Az API az Application Programming Interface rövidítése.
        // Az a felület, amit egy osztály mások számára láthatóvá tesz és használatra felkínál.
        /// <summary>
        /// Létrehozási időpont (immutábilis). Példa getter-only auto-property-re.
        /// </summary>
        public DateTime CreatedAt { get; } = DateTime.Now;
    }
}
