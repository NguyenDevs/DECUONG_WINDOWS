using System;
class Program{
    static void Main(){
        Console.WriteLine("Nhap vao chieu dai cua mang: ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0){
            Console.WriteLine("Vui long nhap vao mot so nguyen duong: ");
        }
        int[] arr = new int[n];
        // Nhập mảng từ bàn phím
        for (int i = 0; i < n; i++){
            Console.Write($"Nhap phan tu thu {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out arr[i])){
                Console.WriteLine("Vui long nhap vao mot so nguyen: ");
            }
        }
        // Tìm phần tử lớn nhất và nhỏ nhất
        int max = arr[0];
        int min = arr[0];
        for (int i = 1; i < n; i++){
            if (arr[i] > max){
                max = arr[i];
            }
            if (arr[i] < min){
                min = arr[i];
            }
        }
        // Hiển thị kết quả
        Console.WriteLine($"Phan tu lon nhat trong mang la: {max}");
        Console.WriteLine($"Phan tu nho nhat trong mang la: {min}");
    }
}
