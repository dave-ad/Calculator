namespace Calculator.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void TestAddition()
        {
            var mainWindow = new MainWindow();

            // Click numbers
            mainWindow.btnNumber_Click(mainWindow.oneBtn, null);
            mainWindow.btnOperation_Click(mainWindow.plusBtn, null);
            mainWindow.btnNumber_Click(mainWindow.twoBtn, null);
            mainWindow.btnEquals_Click(null, null);

            Assert.Equal("3", mainWindow.lblResult.Content);
        }

        [Fact]
        public void TestDivisionByZero()
        {
            var mainWindow = new MainWindow();

            // Click numbers
            mainWindow.btnNumber_Click(mainWindow.oneBtn, null);
            mainWindow.btnOperation_Click(mainWindow.dividebtn, null);
            mainWindow.btnNumber_Click(mainWindow.zeroBtn, null);
            mainWindow.btnEquals_Click(null, null);

            Assert.Equal("Error", mainWindow.lblResult.Content);
        }
    }
}