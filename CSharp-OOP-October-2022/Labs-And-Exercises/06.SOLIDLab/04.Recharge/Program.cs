namespace Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            Worker worker = new Employee("1");
            worker.Work(8);
            Robot robot = new Robot("2", 20);
            robot.Work(20);
            Console.WriteLine(robot.CurrentPower);
            robot.Recharge();
            Console.WriteLine(robot.CurrentPower);
        }
    }
}
