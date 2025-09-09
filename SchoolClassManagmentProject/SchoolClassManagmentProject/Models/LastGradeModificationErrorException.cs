
namespace SchoolClassManagmentProject.Models
{
    [Serializable]
    internal class LastGradeModificationErrorException : Exception
    {
        private string v1;
        private string v2;
        private object value;

        public LastGradeModificationErrorException()
        {
            Console.WriteLine("Something Wrong with Last Grade");
        }

        public LastGradeModificationErrorException(string? message) : base(message)
        {
            Console.WriteLine("Something Wrong with Last Grade" + message);

        }

        public LastGradeModificationErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
            Console.WriteLine("Something Wrong with Last Grade" + message + innerException.Message);
        }

        public LastGradeModificationErrorException(string v1, string v2, object value)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.value = value;
        }
    }
}