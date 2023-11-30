using System;

class Program{
    static void Main(){
        Console.Write("Nhap so nguyen duong n: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0){
            int count = CountOddDecimalDigits(n);
            Console.WriteLine($"So chu so thap phan don le cua {n} la: {count}");
        }
        else{
            Console.WriteLine("Vui long nhap mot so nguyen duong");
        }
    }
    static int CountOddDecimalDigits(int number){
        int count = 0;
        while (number > 0){
            int digit = number % 10;
            if (digit % 2 != 0){
                count++;
            }
            number /= 10;
        }
        return count;
    }
}
