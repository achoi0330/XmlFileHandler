using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ReportsGenerator
{
    public class LinqToXml
    {
        public void GenerateReports(string sourceFilePath, string destinationFilePath)
        {
            var root = XElement.Load(sourceFilePath);
            var studentsList = GetStudentsInASpecificLocation(root, "Auckland");
            WriteNamesToTextFile(studentsList, destinationFilePath);
        }

        private IEnumerable<XElement> GetStudentsInASpecificLocation(XElement root, string location)
        {
            var studentsList =
                from el in root.Elements("Student")
                where (string)el.Element("Location") == location
                select el;

            return studentsList;
        }

        private void WriteNamesToTextFile(IEnumerable<XElement> list, string destinationFilePath)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(destinationFilePath))
            {
                foreach (XElement el in list)
                {
                    file.WriteLine($"{(string)el.Element("FirstName")} {(string)el.Element("LastName")}");
                }
            }
        }


    }
}
