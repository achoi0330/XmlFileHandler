using System;

namespace ReportsGenerator
{
    class ReportsGenerator
    {
        const string sourceXmlFilePath = "/Users/anna/Documents/Students.xml";
        const string destinationTxtFilePath = "/Users/anna/Documents/StudentsFormatted.txt";


        public static void Main(string[] args)
        {
            new LinqToXml().GenerateReports(sourceXmlFilePath, destinationTxtFilePath);
        }

    }
}
