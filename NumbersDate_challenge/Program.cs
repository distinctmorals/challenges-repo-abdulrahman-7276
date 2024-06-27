while (true){
    Console.WriteLine("Please enter a date(yyyy-mm-dd) or type 'exit' to quit: ");
    string userInput = Console.ReadLine();
    if (userInput.ToLower() == "exit"){
        break;
    }
    DateTime userDate;
    bool isValidDate = DateTime.TryParse(userInput, out userDate);
    if (!isValidDate){
        Console.WriteLine("Invalid date format. Please try again.");
        continue;
    }
    DateTime currentDate = DateTime.Now.Date;
    TimeSpan dateDifference = userDate - currentDate;
    int daysDifference = dateDifference.Days;
    if (daysDifference > 0){
        Console.WriteLine($"The day you entered is in {daysDifference} days");
    }
    else if (daysDifference < 0){
        Console.WriteLine($"The day you entered was {Math.Abs(daysDifference)} days ago");
    }
    else {
        Console.WriteLine("the day you entered is today");
    }
}
