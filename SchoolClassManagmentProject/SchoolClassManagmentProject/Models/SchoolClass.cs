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

        /// <summary>
        /// Teljes értékű konstruktor.
        /// </summary>
        /// <param name="grade">Aktuális évfolyam (pl. 11).</param>
        /// <param name="gradeLetter">Osztály betűjele (kis- és nagybetű megengedett).</param>
        /// <param name="lastGrade">Utolsó évfolyam (pl. 12).</param>
        /// <exception cref="ArgumentException">Ha a betűjel nem érvényes.</exception>
        public SchoolClass(byte grade, char gradeLetter, byte lastGrade)
        {
            _grade = grade;

            // Normalize: belső tárolás nagybetűsen (adat-konzisztencia).
            char upperLetter = char.ToUpper(gradeLetter);

            if (!ValidGradeLetters.Contains(upperLetter))
            {
                // Konkrét, akcióképes üzenet és aktuális input visszaadása.
                throw new ArgumentException(
                    $"Érvénytelen osztály betűjel: '{gradeLetter}'. Engedélyezett: {string.Join(", ", ValidGradeLetters)}",
                    nameof(gradeLetter));
            }

            _gradeLetter = upperLetter;
            _lastGrade = lastGrade;
        }

        /// <summary>
        /// Üres konstruktor – a paraméteres konstruktorra láncol, érvényes alapértékekkel.
        /// </summary>
        public SchoolClass()
            : this(byte.MinValue, ValidGradeLetters[0], byte.MinValue)
        {
        }

        // Property-k
        /// <summary>
        /// Aktuális évfolyam (írható).
        /// </summary>
        public byte Grade
        {
            get => _grade;
            set => _grade = value;
        }

        /// <summary>
        /// Osztály betűjele (csak olvasható). Belsőleg mindig nagybetű.
        /// </summary>
        public char GradeLetter => _gradeLetter;

        /// <summary>
        /// Utolsó évfolyam; kívülről nem írható (encapsulation).
        /// </summary>
        public byte LastGrade
        {
            get => _lastGrade;
            private set => _lastGrade = value;
        }

        // Kifejezésalapú property-k
        /// <summary>
        /// Kényelmi, kifejezésalapú property, formázott osztály-névvel (pl. "11. B").
        /// </summary>
        public string Name => $"{_grade}. {_gradeLetter}";

        /// <summary>
        /// Igaz, ha az osztály már túl van az utolsó évfolyamon.
        /// </summary>
        public bool HasGraduated => _grade > _lastGrade;

        /// <summary>
        /// Igaz, ha az osztály az utolsó évfolyamon van.
        /// </summary>
        public bool IsGraduate => _grade == _lastGrade;

        /// <summary>
        /// Igaz, ha az osztály még aktív (nem végzett).
        /// </summary>
        public bool IsActive => !HasGraduated;

        /// <summary>
        /// Az utolsó évfolyam beállítása üzleti szabállyal:
        /// csak akkor emelhető, ha nagyobb, mint az aktuális year (véd a visszaállítástól).
        /// </summary>
        /// <param name="newGrade">Új utolsó évfolyam.</param>
        /// <exception cref="LastGradeModificationErrorException">
        /// Ha a paraméter nem nagyobb a jelenlegi <see cref="Grade"/> értéknél.
        /// </exception>
        public void SetLastGrade(byte newGrade)
        {
            if (newGrade > _grade)
            {
                LastGrade = newGrade;
            }
            else
            {
                // Névvel ellátott paraméter és belső kontextus átadása.
                throw new LastGradeModificationErrorException(
                    $"{nameof(SchoolClass)}.{nameof(SetLastGrade)}: '{nameof(newGrade)}' ({newGrade}) nem nagyobb, mint a jelenlegi '{nameof(Grade)}' ({_grade}).",
                    nameof(newGrade),
                    null
                    );
            }
        }

        /// <summary>
        /// Évfolyam léptetése egy évvel, de csak aktív osztály esetén.
        /// </summary>
        public void AdvanceGrade()
        {
            if (IsActive)
            {
                Grade = (byte)(Grade + 1);
            }
        }

        /// <summary>
        /// Emberbarát string reprezentáció (diagnosztika/log).
        /// </summary>
        public override string ToString()
        {
            // Ipari minta: kis, gyors ToString – kerülje a nehéz hívásokat és kivételeket.
            string status = IsActive ? "aktív" : (HasGraduated ? "végzett" : "érettségiző");
            return $"{Name} | Utolsó évfolyam: {LastGrade} | Státusz: {status} | Létrehozva: {CreatedAt}";
        }
    }
}
