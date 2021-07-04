using System;
using System.Threading.Tasks;

namespace AsyncBreakfast {
    class Program {
        static async Task Main(string[] args) {
            // Starts all the async tasks at once
            Task<Bacon> bacon_task = FryBacon(3);
            Task<Egg> egg_task = FryEggs(2);
            Task<Toast> toast_task = MakeToastWithJamAsync(2);
            
            // Like Promise.all
            await Task.WhenAll(egg_task, bacon_task, toast_task);
            Console.WriteLine("Eggs are ready");
            Console.WriteLine("Bacon is ready");
            Console.WriteLine("Toast is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static void ApplyJam(Toast toast) => Console.WriteLine("Applying jam");
        private static async Task<Toast> MakeToastWithJamAsync(int number) {
            var toast = await ToastBread(number);
            ApplyJam(toast);
            return toast;
        }


        private static async Task<Toast> ToastBread(int slices) {
            for (int i = 0; i < slices; i ++) {
                Console.WriteLine("Putting a slice in the toaster");
            }
            Console.WriteLine("Start toasting");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");
            return new Toast();
        }

        private static async Task<Bacon> FryBacon(int slices) {
            Console.WriteLine("Cooking first side of bacon");
            await Task.Delay(3000);
            Console.WriteLine("Cooking second side of bacon");
            await Task.Delay(3000);
            return new Bacon();
        }

        private static async Task<Egg> FryEggs(int number) {
            Console.WriteLine("Warming egg pan");
            await Task.Delay(3000);
            Console.WriteLine("Cooking eggs");
            await Task.Delay(3000);
            return new Egg();
        }

        private static Coffee PourCoffee() {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }

    internal class Coffee {
    }
    internal class Egg {
    }
    internal class Bacon {
    }
    internal class Toast {
    }
    internal class Juice {
    }
}
