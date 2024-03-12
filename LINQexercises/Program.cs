namespace LINQexercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker worker1 = new Worker("Aneliya", "Mechkarova", 27);
            Worker worker2 = new Worker("Ivan", "Ivanov", 24);
            Worker worker3 = new Worker("Petko", "Petkov", 18);
            Worker worker4 = new Worker("Georgi", "Georgiev", 20);
            Worker worker5 = new Worker("Georgi", "Georgievv", 20);
            Worker worker6 = new Worker("Georgi", "Angelov", 20);
            Worker[] workers = {worker1,  worker2, worker3, worker4, worker5, worker6};

            var allWorkerBetween18and24Lambda = workers.Where(w => w.Age > 18 && w.Age < 24);
            var allWorkerBetween18and24 = from worker in workers
                        where worker.Age > 18 && worker.Age < 20
                        select worker;

            var workersOrderByFirstAndLastNameDescLambda = workers.OrderByDescending(w => w.FirstName).ThenByDescending(w => w.LastName).ToList();
            foreach (var worker in workersOrderByFirstAndLastNameDescLambda)
            {
                Console.WriteLine(worker.FirstName + " " + worker.LastName);
            }

            var workersOrderByFirstAndLastNameDesc = (from worker in workers
                          orderby worker.FirstName descending, worker.LastName descending
                          select worker).ToList();
            foreach ( var worker in workersOrderByFirstAndLastNameDesc)
            {
                Console.WriteLine(worker.FirstName + " " + worker.LastName);
            }

            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };

            var allNumbersDivisibleBy7and3Lambda = numbers.Where(n => n % 3 == 0 && n % 7 == 0).ToList();
            foreach(var number in allNumbersDivisibleBy7and3Lambda)
            {
                Console.WriteLine(number);
            }

            var allNumbersDivisibleBy7and3 = (from number in numbers
                                              where number % 3 == 0 && number % 7 == 0
                                              select number).ToList();

            foreach (var number in allNumbersDivisibleBy7and3)
            {
                Console.WriteLine(number);
            }

        }
    }
}
