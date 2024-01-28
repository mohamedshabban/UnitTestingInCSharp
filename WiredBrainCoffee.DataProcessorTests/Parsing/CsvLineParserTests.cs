using WiredBrainCoffee.DataProcessor.Model;

namespace WiredBrainCoffee.DataProcessor.Parsing
{
    public class CsvLineParserTests
    {
        [Fact]
        public void ShouldParseValidLine()
        {
            //Arrange
            string[] csvLines = new string[] { "Espresso;10/27/2022 8:01:16 AM" };
            //Act
            MachineDataItem[] machineDataItems =
                CsvLineParser.Parse(csvLines);

            //Assert
            Assert.NotNull(machineDataItems[0]);
            Assert.Single(machineDataItems);
            Assert.Equal("Espresso", machineDataItems[0].CoffeeType);
            Assert.Equal(new DateTime(2022, 10, 27, 8, 1, 16, 0), machineDataItems[0].CreatedAt);
        }
        [Fact]
        public void ShouldSkipEmptyLine()
        {
            //Arrange
            string[] csvLines = new string[] { " ", "" };
            //Act
            MachineDataItem[] machineDataItems =
                CsvLineParser.Parse(csvLines);

            //Assert
            Assert.NotNull(machineDataItems);
            Assert.Empty(machineDataItems);
        }
    }
}
