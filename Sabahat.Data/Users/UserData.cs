using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sabahat.Common;

namespace Sabahat.Data.Users
{
    public class UserData : IUserData
    {
        public List<User> GetUsers()
        {
            try
            {
                var sourcePath = GetPath();
                var allFiles = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories).ToList();
                var users = ReadAllLines(sourcePath, allFiles);

                return users;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<User> PostUsers(List<User> users)
        {
            try
            {
                var sourcePath = GetPath();
                var allFiles = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories).ToList();
                var sampleInputFiler = allFiles.Find(r => Path.GetFileName(r) == "input.csv");
                var lastIndex = File.ReadAllLines(sampleInputFiler).Length;
                foreach (var item in users)
                {
                    lastIndex++;

                    var newLine = Environment.NewLine + item.Name + ", " + item.LastName + ", " + item.ZipCode + " " +
                                item.City + ", " + item.JobLevel;
                    File.AppendAllText(sampleInputFiler, newLine);

                    item.Id = lastIndex;
                }

                return users;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private string GetPath()
        {
            try
            {
                var BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                //Test Directory
                var testIndex = BaseDirectory.IndexOf("Sabahat.WebAPI.Tests");
                if (testIndex != -1)
                    BaseDirectory = BaseDirectory.Substring(0, testIndex) + "Sabahat.WebAPI\\";

                var sourcePath = BaseDirectory + "DataSources";
                if (!Directory.Exists(sourcePath))
                    throw new Exception("Source Directory Not Found on:" + sourcePath);

                return sourcePath;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private List<User> ReadAllLines(string sourcePath, List<string> allFiles)
        {
            try
            {
                var users = new List<User>();

                allFiles.ForEach(r =>
                {
                    var fileContents = File.ReadAllLines(sourcePath + "\\" + Path.GetFileName(r));

                    int i = 1;
                    foreach (var item in fileContents)
                    {
                        var columns = item.Split(',');
                        var zipCode = string.Empty;
                        var city = string.Empty;
                        var jobLevel = string.Empty;

                        for (var j = 0; j < columns.Count(); j++)
                        {
                            var zipCityCol = columns[j].Trim().Split(' ');
                            if (zipCityCol.Count() > 1)
                            {
                                zipCode = zipCityCol[0];
                                for (int k = 1; k < zipCityCol.Count(); k++)
                                    city = city + zipCityCol[k] + " ";
                                city = city.Trim();
                            }
                            if (columns[j].IsNumber())
                                jobLevel = columns[j].Trim().ToJobLevel();
                        }

                        users.Add(new User
                        {
                            Id = i,
                            Name = !columns[0].IsNumber() ? (columns[0].Is2ColumnIn1() ? string.Empty : columns[0].Trim()) : string.Empty,
                            LastName = (!columns[1].IsNumber() && columns.Count() > 1) ? (columns[1].Is2ColumnIn1() ? string.Empty : columns[1].Trim()) : string.Empty,
                            ZipCode = columns.Count() > 2 ? (columns[2].Is2ColumnIn1() ? zipCode : string.Empty) : zipCode,
                            City = columns.Count() > 2 ? (columns[2].Is2ColumnIn1() ? city : string.Empty) : city,
                            JobLevel = columns.Count() > 3 ? (columns[3].Is2ColumnIn1() ? string.Empty : jobLevel) : jobLevel,
                        });
                        i++;
                    }
                });

                return users;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
