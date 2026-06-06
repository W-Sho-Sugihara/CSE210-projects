// used a Fisher-Yates shuffle to randomize the prompt questions in the reflection activity.
// used % to prevent repeating reflection prompt questions
// jumped the gun with polymorphism with the Run function in the parent class
class Program
{
    static void Main(string[] args)
    {
         while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Mindfulness App ===\n");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Breathing Activity");
                Console.WriteLine("  2. Reflection Activity");
                Console.WriteLine("  3. Listing Activity");
                Console.WriteLine("  4. Quit\n");
                Console.Write("Select an option: ");
 
                string choice = Console.ReadLine();
 
                Activity activity = choice switch
                {
                    "1" => new Breathing(
                        "Breathing Activity",
                        "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus on your breathing."),
                    "2" => new Reflection(
                        "Reflection Activity",
                        "This activity will help you reflect on times in your life when you have shown strength\nand resilience. This will help you recognize the power you have and how you can use it\nin other aspects of your life."),
                    "3" => new Listing(
                        "Listing Activity",
                        "This activity will help you reflect on the good things in your life by having you\nlist as many things as you can in a certain area."),
                    "4" => null,
                    _   => null
                };
 
                if (choice == "4")
                {
                    Console.WriteLine("\nGoodbye!");
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }
 
                if (activity == null)
                {
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }
 
                activity.Run();
 
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
    }
}