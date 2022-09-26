namespace AsyncProject
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region Thread
            //Thread currentThread = Thread.CurrentThread;

            ////получаем имя потока
            //Console.WriteLine($"Имя потока: {currentThread.Name}");
            //currentThread.Name = "Метод Main";
            //Console.WriteLine($"Имя потока: {currentThread.Name}");

            //Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
            //Console.WriteLine($"Id потока: {currentThread.ManagedThreadId}");
            //Console.WriteLine($"Приоритет потока: {currentThread.Priority}");
            //Console.WriteLine($"Статус потока: {currentThread.ThreadState}");
            // создаем новый поток
            //Thread myThread1 = new Thread(Print);
            //Thread myThread2 = new Thread(new ThreadStart(Print));
            //Thread myThread3 = new Thread(() => Console.WriteLine("Hello Threads"));
            //myThread1.Start();  // запускаем поток myThread1
            //myThread2.Start();  // запускаем поток myThread2
            //myThread3.Start();  // запускаем поток myThread3
            //void Print() => Console.WriteLine("Hello Threads");
            // создаем новый поток
            //Thread myThread = new Thread(Print);
            //myThread.Priority = ThreadPriority.Highest;
            //// запускаем поток myThread
            //myThread.Start();
            //// действия, выполняемые в главном потоке
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine($"Главный поток: {i}");
            //    Thread.Sleep(300);
            //}
            //// действия, выполняемые во втором потокке
            //void Print()
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        Console.WriteLine($"Второй поток: {i}");
            //        Thread.Sleep(400);
            //    }
            //}
            // создаем новые потоки
            //Thread myThread1 = new Thread(new ParameterizedThreadStart(Print));
            //Thread myThread2 = new Thread(Print);
            //Thread myThread3 = new Thread(message => Console.WriteLine(message));
            //// запускаем потоки
            //myThread1.Start("Hello");
            //myThread2.Start("Привет");
            //myThread3.Start("Salut");
            //void Print(object? message) => Console.WriteLine(message);
            //int x = 0;
            //// запускаем пять потоков
            //for (int i = 1; i < 6; i++)
            //{
            //    Thread myThread = new(Print);
            //    myThread.Name = $"Поток {i}";   // устанавливаем имя для каждого потока
            //    myThread.Start();
            //}
            //void Print()
            //{
            //    x = 1;
            //    for (int i = 1; i < 6; i++)
            //    {
            //        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            //        x++;
            //        Thread.Sleep(100);
            //    }
            //}
            //int x = 0;
            //object locker = new();  // объект-заглушка
            //                        // запускаем пять потоков
            //for (int i = 1; i < 6; i++)
            //{
            //    Thread myThread = new(Print);
            //    myThread.Name = $"Поток {i}";
            //    myThread.Start();
            //}
            //void Print()
            //{
            //    lock (locker)
            //    {
            //        x = 1;
            //        for (int i = 1; i < 6; i++)
            //        {
            //            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            //            x++;
            //            Thread.Sleep(100);
            //        }
            //    }
            //}
            //int x = 0;
            //object locker = new();  // объект-заглушка
            //                        // запускаем пять потоков
            //for (int i = 1; i < 6; i++)
            //{
            //    Thread myThread = new(Print);
            //    myThread.Name = $"Поток {i}";
            //    myThread.Start();
            //}
            //void Print()
            //{
            //    bool acquiredLock = false;
            //    try
            //    {
            //        Monitor.Enter(locker, ref acquiredLock);
            //        x = 1;
            //        for (int i = 1; i < 6; i++)
            //        {
            //            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            //            x++;
            //            Thread.Sleep(100);
            //        }
            //    }
            //    finally
            //    {
            //        if (acquiredLock) Monitor.Exit(locker);
            //    }
            //} 
            #endregion

            #region Task
            //Task task = new Task(() => Console.WriteLine("Hello Task!"));
            //task.Start();
            //Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
            //task1.Start();

            //Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));

            //Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));

            //task1.Wait();   // ожидаем завершения задачи task1
            //task2.Wait();   // ожидаем завершения задачи task2
            //task3.Wait();   // ожидаем завершения задачи task3 
            #endregion

            //Returned types 
            //void
            //Task
            //Task<T>
            //ValueTask<T>
            //Test();
            // определение асинхронного метода
            //await PrintAsync();   // вызов асинхронного метода
            //Console.WriteLine("Некоторые действия в методе Main");
            //Test();
            //await PrintAsync("Hello world");
            //int n1 = await SquareAsync(5);
            //int n2 = await SquareAsync(6);
            //Console.WriteLine($"n1={n1}  n2={n2}"); // n1=25  n2=36

            var result = await AddAsync(4, 5);
            Console.WriteLine(result);
        }

        static ValueTask<int> AddAsync(int a, int b)
        {
            return new ValueTask<int>(a + b);
        }

        static async Task<int> SquareAsync(int n)
        {
            await Task.Delay(0);
            return n * n;
        }

        static async Task PrintAsync(string message)
        {
            await Task.Delay(1000);     // имитация продолжительной работы
            Console.WriteLine(message);
        }

        //static async void Test()
        //{
        //    PrintAsync("Hello World");
        //    PrintAsync("How are you?");
        //    Console.WriteLine("Main End");
        //    await Task.Delay(3000); // ждем завершения задач
        //}

        //static async void Test()
        //{
        //    await PrintAsync();
        //}

        //static async Task PrintAsync()
        //{
        //    Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
        //    await Task.Run(() => Print());                // выполняется асинхронно
        //    Console.WriteLine("Конец метода PrintAsync");
        //}

        //static void Print()
        //{
        //    Thread.Sleep(3000);     // имитация продолжительной работы
        //    Console.WriteLine("Hello world!");
        //}
        //static async void PrintAsync(string message)
        //{
        //    await Task.Delay(1000);     // имитация продолжительной работы
        //    Console.WriteLine(message);
        //}
    }
}