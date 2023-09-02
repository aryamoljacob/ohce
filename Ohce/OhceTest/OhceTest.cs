using Ohce;

namespace OhceTest;

public class OhceTest
{
    OhceMethods om = new OhceMethods();


    [Theory]
    [InlineData("20:00:00", "Ohce User001", "¡Buenas noches User001!")]
    [InlineData("22:00:00", "Ohce User002", "¡Buenas noches User002!")]
    [InlineData("23:59:59", "Ohce User001", "¡Buenas noches User001!")]
    [InlineData("00:00:00", "Ohce User002", "¡Buenas noches User002!")]
    [InlineData("02:30:59", "Ohce User001", "¡Buenas noches User001!")]
    [InlineData("05:59:59", "Ohce User002", "¡Buenas noches User002!")]
    [InlineData("06:00:00", "Ohce User001", "¡Buenos días User001!")]
    [InlineData("10:30:00", "Ohce User002", "¡Buenos días User002!")]
    [InlineData("11:59:59", "Ohce User001", "¡Buenos días User001!")]
    [InlineData("12:00:00", "Ohce User002", "¡Buenas tardes User002!")]
    [InlineData("15:30:00", "Ohce User001", "¡Buenas tardes User001!")]
    [InlineData("19:59:59", "Ohce User002", "¡Buenas tardes User002!")]
    public void TestGreeting(string time, string startString, string expected)
    {
        TimeSpan timeNow = TimeSpan.Parse(time);

        string greeting = om.GetGreeting(timeNow, startString);
        Assert.True(expected == greeting, $"Time {timeNow} - expected {expected} but received {greeting}");

    }

    [Theory]
    [InlineData("test", "tset",false)]
    [InlineData("Test", "tseT", false)]
    [InlineData(" ", " ", false)]
    [InlineData("", "", false)]
    [InlineData("aaa", "aaa\n¡Bonita palabra!", false)]
    [InlineData("STOP", "POTS", false)]
    [InlineData("STOP$", "$POTS", false)]
    public void TestOhceResponse(string text, string ohceResp, bool quitLoop)
    {

        Tuple<string, bool> reverseText = om.Ohce(text);
        Assert.True(ohceResp == reverseText.Item1, $"expected {ohceResp} but received {reverseText.Item1}");
        Assert.False(quitLoop, $"expected quitloop {quitLoop} but received {reverseText.Item2}");

    }

    [Theory]
    [InlineData("Ohce User001", "Stop!", "Adios User001",true)]
    [InlineData("Ohce User_002", "STOP!", "Adios User_002", true)]
    public void TestOhceStop(string startString, string text, string ohceResp, bool quitLoop)
    {
        TimeSpan timeNow = new TimeSpan(6, 0, 0);
        string greeting = om.GetGreeting(timeNow, startString);

        Tuple<string, bool> reverseText = om.Ohce(text);
        Assert.True(ohceResp == reverseText.Item1, $"expected {ohceResp} but received {reverseText.Item1}");
        Assert.True(quitLoop, $"expected quitloop {quitLoop} but received {reverseText.Item2}");

    }

    [Theory]
    [InlineData("20:00:00", "Ohce ", "Please enter: Ohce <your FirstName> to start")]
    [InlineData("6:00:00", "Test User002", "Please enter: Ohce <your FirstName> to start")]
    [InlineData("12:30:59", "Ohce", "Please enter: Ohce <your FirstName> to start")]
    public void TestGreetingErrorInStartMessage(string time, string startString, string expected)
    {
        TimeSpan timeNow = TimeSpan.Parse(time);

        string greeting = om.GetGreeting(timeNow, startString);
        Assert.True(expected == greeting, $"Time {timeNow} - expected {expected} but received {greeting}");

    }

}
