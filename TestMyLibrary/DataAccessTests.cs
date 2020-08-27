using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MyLibrary.Test
{
    namespace DataAccessTests
    {
        public class AddPersonToPeopleListTests
        {
            [Fact]
            public void AddPersonToPeopleList_リストにPersonが追加される()
            {
                //Arrange
                PersonModel newPerson = new PersonModel { FirstName = "Tim", LastName = "Corey" };
                List<PersonModel> people = new List<PersonModel>();

                //Act
                DataAccess.AddPersonToPeopleList(people, newPerson);

                //Assert
                Assert.True(people.Count == 1);
                Assert.Contains<PersonModel>(newPerson, people);
            }

            [Theory]
            [InlineData("Tim", "", nameof(PersonModel.LastName))]
            [InlineData("", "Corey", nameof(PersonModel.FirstName))]
            public void AddPersonToPeopleList_リストにPerson追加に失敗する(string firstName, string lastName, string paramName)
            {
                //Assert
                Assert.Throws<ArgumentException>(paramName, () =>
                {
                    //Arrange
                    PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
                    List<PersonModel> people = new List<PersonModel>();

                    //Act
                    DataAccess.AddPersonToPeopleList(people, newPerson);
                });
            }
        }

        public class ConvertModelsToCSVTests
        {
            [Fact]
            public void ConvertModelsToCSV_Listの各アイテムがCSV形式に変換される()
            {
                //Arrange
                List<PersonModel> people = new List<PersonModel>();
                people.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
                people.Add(new PersonModel { FirstName = "Shu", LastName = "Nishi" });

                //Act
                List<string> csv = DataAccess.ConvertModelsToCSV(people);

                //Assert
                Assert.Equal(people[0].FirstName, csv[0].Split(',')[0]);
                Assert.Equal(people[0].LastName, csv[0].Split(',')[1]);
                Assert.Equal(people[1].FirstName, csv[1].Split(',')[0]); 
                Assert.Equal(people[1].LastName, csv[1].Split(',')[1]);
                Assert.Equal(people.Count, csv.Count);
            }
        }

        public class ConvertCSVToModelTests
        {
            [Fact]
            public void ConvertCSVToModel_CSV形式のリストがModelに変換される()
            {
                //Arrange
                string[] content = new string[] { "Tim,Corey","Shu,Nishi"};

                //Act
                List<PersonModel> people = DataAccess.ConvertCSVToModel(content);

                //Assert
                Assert.Equal(content.Length, people.Count);
                Assert.Equal(content[0].Split(',')[0], people[0].FirstName);
                Assert.Equal(content[0].Split(',')[1], people[0].LastName);
                Assert.Equal(content[1].Split(',')[0], people[1].FirstName);
                Assert.Equal(content[1].Split(',')[1], people[1].LastName);
            }
        }
    }
}
